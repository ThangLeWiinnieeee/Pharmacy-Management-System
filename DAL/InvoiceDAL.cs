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
        var phone = string.IsNullOrWhiteSpace(request.CustomerPhone) ? null : request.CustomerPhone.Trim();

        // Điểm tích lũy chỉ áp dụng cho khách hàng đã có trong hệ thống (theo SĐT)
        var customer = phone is null ? null : context.Customers.FirstOrDefault(c => c.Phone == phone);

        // Trừ điểm: kẹp trong [0, điểm hiện có] và không vượt số tiền phải trả (1 điểm = 1đ)
        var payableBeforePoints = totalAmount - request.Discount;
        if (payableBeforePoints < 0) payableBeforePoints = 0;

        var pointsUsed = 0;
        if (customer is not null && request.PointsUsed > 0)
        {
            pointsUsed = Math.Min(request.PointsUsed, customer.Points);
            pointsUsed = (int)Math.Min(pointsUsed, payableBeforePoints);
            if (pointsUsed < 0) pointsUsed = 0;
        }

        var finalAmount = payableBeforePoints - pointsUsed;
        if (finalAmount < 0) finalAmount = 0;

        // Cộng điểm: 1 điểm cho mỗi 1.000đ thực trả, chỉ khi có khách hàng
        var pointsEarned = customer is not null ? (int)(finalAmount / 1000m) : 0;

        var invoice = new Invoice
        {
            InvoiceCode = invoiceCode,
            CustomerId = customer?.Id,
            CustomerName = string.IsNullOrWhiteSpace(request.CustomerName) ? customer?.Name : request.CustomerName.Trim(),
            CustomerPhone = phone,
            CreatedByUserId = request.CreatedByUserId,
            TotalAmount = totalAmount,
            Discount = request.Discount,
            FinalAmount = finalAmount,
            PointsUsed = pointsUsed,
            PointsEarned = pointsEarned,
            Note = string.IsNullOrWhiteSpace(request.Note) ? null : request.Note.Trim(),
            Status = "Completed",
            CreatedAt = DateTime.Now
        };

        // Cập nhật số dư điểm của khách
        if (customer is not null)
        {
            customer.Points = customer.Points - pointsUsed + pointsEarned;
        }

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

    public List<InvoiceDTO> GetInvoices(InvoiceQueryDTO query)
    {
        using var context = new AppDbContext();

        var invoicesQuery = context.Invoices
            .AsNoTracking()
            .Include(i => i.Details)
            .Include(i => i.CreatedByUser)
            .AsQueryable();

        var keyword = query.Keyword.Trim();
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            invoicesQuery = invoicesQuery.Where(i =>
                i.InvoiceCode.Contains(keyword) ||
                (i.CustomerName != null && i.CustomerName.Contains(keyword)) ||
                (i.CustomerPhone != null && i.CustomerPhone.Contains(keyword)) ||
                (i.CreatedByUser != null && i.CreatedByUser.FullName.Contains(keyword)));
        }

        if (query.DateFrom.HasValue)
        {
            var dateFrom = query.DateFrom.Value.Date;
            invoicesQuery = invoicesQuery.Where(i => i.CreatedAt >= dateFrom);
        }

        if (query.DateTo.HasValue)
        {
            var dateToExclusive = query.DateTo.Value.Date.AddDays(1);
            invoicesQuery = invoicesQuery.Where(i => i.CreatedAt < dateToExclusive);
        }

        if (!string.IsNullOrWhiteSpace(query.StatusFilter) && query.StatusFilter != "Tất cả")
        {
            var status = query.StatusFilter.Trim();
            invoicesQuery = invoicesQuery.Where(i => i.Status == status);
        }

        return invoicesQuery
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
                PointsEarned = i.PointsEarned,
                PointsUsed = i.PointsUsed,
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

    public List<InvoiceDTO> GetAll()
    {
        return GetInvoices(new InvoiceQueryDTO());
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
            PointsEarned = invoice.PointsEarned,
            PointsUsed = invoice.PointsUsed,
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
