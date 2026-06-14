using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.DAL;

public class InvoiceDAL : IInvoiceDAL
{
    public InvoiceDTO Create(CreateInvoiceDTO request)
    {
        using var context = new AppDbContext();

        // Tạo mã hóa đơn tự động: HD + timestamp
        var invoiceCode = "HD" + DateTime.Now.ToString("yyMMddHHmmss");

        var totalAmount = request.Details.Sum(d => d.LineTotal);
        var finalAmount = totalAmount - request.Discount;

        var invoice = new Invoice
        {
            InvoiceCode = invoiceCode,
            CustomerName = string.IsNullOrWhiteSpace(request.CustomerName) ? null : request.CustomerName.Trim(),
            CustomerPhone = string.IsNullOrWhiteSpace(request.CustomerPhone) ? null : request.CustomerPhone.Trim(),
            CreatedByUserId = request.CreatedByUserId,
            TotalAmount = totalAmount,
            Discount = request.Discount,
            FinalAmount = finalAmount < 0 ? 0 : finalAmount,
            Note = string.IsNullOrWhiteSpace(request.Note) ? null : request.Note.Trim(),
            Status = "Completed",
            CreatedAt = DateTime.Now
        };

        foreach (var d in request.Details)
        {
            invoice.Details.Add(new InvoiceDetail
            {
                MedicineId = d.MedicineId,
                MedicineCode = d.MedicineCode,
                MedicineName = d.MedicineName,
                Unit = d.Unit,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice,
                LineTotal = d.LineTotal
            });
        }

        context.Invoices.Add(invoice);

        // Trừ tồn kho
        foreach (var d in request.Details)
        {
            var medicine = context.Medicines.FirstOrDefault(m => m.Id == d.MedicineId);
            if (medicine is not null)
            {
                medicine.Quantity -= d.Quantity;
                if (medicine.Quantity < 0)
                {
                    medicine.Quantity = 0;
                }
            }
        }

        context.SaveChanges();

        return MapToDTO(invoice, context);
    }

    public List<InvoiceDTO> GetAll()
    {
        using var context = new AppDbContext();

        return context.Invoices
            .AsNoTracking()
            .Include(i => i.Details)
            .Include(i => i.CreatedByUser)
            .OrderByDescending(i => i.CreatedAt)
            .Select(i => new InvoiceDTO
            {
                Id = i.Id,
                InvoiceCode = i.InvoiceCode,
                CustomerName = i.CustomerName,
                CustomerPhone = i.CustomerPhone,
                CreatedByFullName = i.CreatedByUser != null ? i.CreatedByUser.FullName : string.Empty,
                TotalAmount = i.TotalAmount,
                Discount = i.Discount,
                FinalAmount = i.FinalAmount,
                Note = i.Note,
                Status = i.Status,
                CreatedAt = i.CreatedAt,
                Details = i.Details.Select(d => new InvoiceDetailDTO
                {
                    Id = d.Id,
                    MedicineId = d.MedicineId,
                    MedicineCode = d.MedicineCode,
                    MedicineName = d.MedicineName,
                    Unit = d.Unit,
                    Quantity = d.Quantity,
                    UnitPrice = d.UnitPrice,
                    LineTotal = d.LineTotal
                }).ToList()
            })
            .ToList();
    }

    private static InvoiceDTO MapToDTO(Invoice invoice, AppDbContext context)
    {
        var createdBy = context.Users.AsNoTracking().FirstOrDefault(u => u.Id == invoice.CreatedByUserId);

        return new InvoiceDTO
        {
            Id = invoice.Id,
            InvoiceCode = invoice.InvoiceCode,
            CustomerName = invoice.CustomerName,
            CustomerPhone = invoice.CustomerPhone,
            CreatedByFullName = createdBy?.FullName ?? string.Empty,
            TotalAmount = invoice.TotalAmount,
            Discount = invoice.Discount,
            FinalAmount = invoice.FinalAmount,
            Note = invoice.Note,
            Status = invoice.Status,
            CreatedAt = invoice.CreatedAt,
            Details = invoice.Details.Select(d => new InvoiceDetailDTO
            {
                Id = d.Id,
                MedicineId = d.MedicineId,
                MedicineCode = d.MedicineCode,
                MedicineName = d.MedicineName,
                Unit = d.Unit,
                Quantity = d.Quantity,
                UnitPrice = d.UnitPrice,
                LineTotal = d.LineTotal
            }).ToList()
        };
    }
}
