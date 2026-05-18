using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.DAL;

public class MedicineDAL : IMedicineDAL
{
    private const int LowStockThreshold = 10;
    private const int ExpiringSoonDays = 30;

    public List<Medicine> GetMedicines(MedicineQueryDTO query)
    {
        using var context = new AppDbContext();

        var medicines = context.Medicines.AsNoTracking().AsQueryable();
        var keyword = (query.Keyword ?? string.Empty).Trim();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            medicines = medicines.Where(medicine =>
                medicine.Code.Contains(keyword)
                || medicine.Name.Contains(keyword)
                || (medicine.Manufacturer != null && medicine.Manufacturer.Contains(keyword)));
        }

        medicines = ApplyStatusFilter(medicines, query.StatusFilter);

        return medicines
            .OrderByDescending(medicine => medicine.IsActive)
            .ThenBy(medicine => medicine.Name)
            .ToList();
    }

    public Medicine? GetById(int id)
    {
        using var context = new AppDbContext();
        return context.Medicines.AsNoTracking().FirstOrDefault(medicine => medicine.Id == id);
    }

    public bool ExistsByCode(string code, int? excludedId = null)
    {
        using var context = new AppDbContext();
        var normalizedCode = code.Trim();

        return context.Medicines.Any(medicine =>
            medicine.Code == normalizedCode
            && (!excludedId.HasValue || medicine.Id != excludedId.Value));
    }

    public Medicine Add(Medicine medicine)
    {
        using var context = new AppDbContext();

        context.Medicines.Add(medicine);
        context.SaveChanges();

        return medicine;
    }

    public void Update(Medicine medicine)
    {
        using var context = new AppDbContext();

        context.Medicines.Update(medicine);
        context.SaveChanges();
    }

    public void SetActive(int id, bool isActive)
    {
        using var context = new AppDbContext();
        var medicine = context.Medicines.FirstOrDefault(item => item.Id == id);

        if (medicine is null)
        {
            return;
        }

        medicine.IsActive = isActive;
        context.SaveChanges();
    }

    private static IQueryable<Medicine> ApplyStatusFilter(IQueryable<Medicine> medicines, string? statusFilter)
    {
        var today = DateTime.Today;
        var expiringSoonDate = today.AddDays(ExpiringSoonDays);

        return statusFilter switch
        {
            "Đang kinh doanh" => medicines.Where(medicine => medicine.IsActive),
            "Ngừng bán" => medicines.Where(medicine => !medicine.IsActive),
            "Sắp hết hàng" => medicines.Where(medicine => medicine.IsActive && medicine.Quantity <= LowStockThreshold),
            "Sắp hết hạn" => medicines.Where(medicine =>
                medicine.IsActive
                && medicine.ExpiryDate.HasValue
                && medicine.ExpiryDate.Value.Date >= today
                && medicine.ExpiryDate.Value.Date <= expiringSoonDate),
            _ => medicines
        };
    }
}
