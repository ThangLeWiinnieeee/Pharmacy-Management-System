using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Entities;

namespace PharmacyManagementSystem.DAL;

public class MedicineBatchDAL
{
    public List<MedicineBatchDTO> GetByMedicineId(int medicineId)
    {
        using var db = new AppDbContext();
        return db.MedicineBatches
            .Where(b => b.MedicineId == medicineId)
            .OrderByDescending(b => b.ImportDate)
            .Select(b => new MedicineBatchDTO
            {
                Id = b.Id,
                MedicineId = b.MedicineId,
                ImportDate = b.ImportDate,
                ImportQuantity = b.ImportQuantity,
                ExpiryDate = b.ExpiryDate,
                ImportPrice = b.ImportPrice,
                Note = b.Note
            })
            .ToList();
    }

    public void Update(int batchId, DateTime importDate, int importQuantity,
                       DateTime expiryDate, decimal importPrice, string? note)
    {
        using var db = new AppDbContext();

        var batch = db.MedicineBatches.Find(batchId)
            ?? throw new Exception("Không tìm thấy lô hàng.");

        var qtyDelta = importQuantity - batch.ImportQuantity;

        batch.ImportDate     = importDate;
        batch.ImportQuantity = importQuantity;
        batch.ExpiryDate     = expiryDate;
        batch.ImportPrice    = importPrice;
        batch.Note           = string.IsNullOrWhiteSpace(note) ? null : note.Trim();

        var medicine = db.Medicines.Find(batch.MedicineId);
        if (medicine is not null)
        {
            medicine.Quantity    += qtyDelta;
            medicine.ImportPrice  = importPrice;

            var otherExpiries = db.MedicineBatches
                .Where(b => b.MedicineId == batch.MedicineId && b.Id != batchId && b.ExpiryDate.HasValue)
                .Select(b => b.ExpiryDate!.Value)
                .ToList();
            otherExpiries.Add(expiryDate);
            medicine.ExpiryDate = otherExpiries.Min();
        }

        db.SaveChanges();
    }

    public void Add(int medicineId, DateTime importDate, int importQuantity,
                    DateTime? expiryDate, decimal importPrice, string? note)
    {
        using var db = new AppDbContext();

        db.MedicineBatches.Add(new MedicineBatch
        {
            MedicineId = medicineId,
            ImportDate = importDate,
            ImportQuantity = importQuantity,
            ExpiryDate = expiryDate,
            ImportPrice = importPrice,
            Note = string.IsNullOrWhiteSpace(note) ? null : note.Trim()
        });

        var medicine = db.Medicines.Find(medicineId);
        if (medicine is not null)
        {
            medicine.Quantity += importQuantity;
            medicine.ImportPrice = importPrice;
            if (expiryDate.HasValue &&
                (!medicine.ExpiryDate.HasValue || expiryDate.Value < medicine.ExpiryDate.Value))
                medicine.ExpiryDate = expiryDate.Value;
        }

        db.SaveChanges();
    }
}
