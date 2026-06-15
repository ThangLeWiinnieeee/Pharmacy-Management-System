using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IDAL;
using static PharmacyManagementSystem.MedicineStatusHelper;

namespace PharmacyManagementSystem.DAL;

public class DashboardDAL : IDashboardDAL
{
    private const string AdminRole = "Admin";
    private const string StaffRole = "Staff";

    public DashboardStatsDTO GetStats()
    {
        using var context = new AppDbContext();

        var today = DateTime.Today;
        var nearExpiryDate = today.AddMonths(MedicineStatusHelper.NearExpiryMonths);
        var activeMedicines = context.Medicines.Where(medicine => medicine.IsActive);
        var activeUsers = context.Users.Where(user => user.IsActive);

        return new DashboardStatsDTO
        {
            TotalMedicineTypes    = context.Medicines.Count(),
            ActiveMedicineTypes   = activeMedicines.Count(),
            TotalStockQuantity    = activeMedicines.Sum(medicine => (int?)medicine.Quantity) ?? 0,
            LowStockMedicineTypes = activeMedicines.Count(medicine =>
                medicine.Quantity > 0
                && medicine.Quantity < LowStockThreshold),
            ExpiringSoonMedicineTypes = activeMedicines.Count(medicine =>
                medicine.Quantity > 0
                && medicine.ExpiryDate.HasValue
                && medicine.ExpiryDate.Value.Date >= today
                && medicine.ExpiryDate.Value.Date < nearExpiryDate),
            StoppedMedicineTypes = context.Medicines.Count(m => !m.IsActive),
            ExpiredMedicineTypes = activeMedicines.Count(m =>
                m.ExpiryDate.HasValue && m.ExpiryDate.Value.Date < today),
            AdminCount    = activeUsers.Count(user => user.Role == AdminRole),
            StaffCount    = activeUsers.Count(user => user.Role == StaffRole),
            CustomerCount = context.Customers.Count()
        };
    }
}
