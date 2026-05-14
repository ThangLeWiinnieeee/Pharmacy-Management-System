using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.DAL;

public class DashboardDAL : IDashboardDAL
{
    private const int LowStockThreshold = 10;
    private const int ExpiringSoonDays = 30;
    private const string AdminRole = "Admin";
    private const string StaffRole = "Staff";

    public DashboardStatsDTO GetStats()
    {
        using var context = new AppDbContext();

        var today = DateTime.Today;
        var expiringSoonDate = today.AddDays(ExpiringSoonDays);
        var activeMedicines = context.Medicines.Where(medicine => medicine.IsActive);
        var activeUsers = context.Users.Where(user => user.IsActive);

        return new DashboardStatsDTO
        {
            TotalMedicineTypes = context.Medicines.Count(),
            ActiveMedicineTypes = activeMedicines.Count(),
            TotalStockQuantity = activeMedicines.Sum(medicine => (int?)medicine.Quantity) ?? 0,
            LowStockMedicineTypes = activeMedicines.Count(medicine => medicine.Quantity <= LowStockThreshold),
            ExpiringSoonMedicineTypes = activeMedicines.Count(
                medicine => medicine.ExpiryDate.HasValue
                    && medicine.ExpiryDate.Value.Date >= today
                    && medicine.ExpiryDate.Value.Date <= expiringSoonDate),
            AdminCount = activeUsers.Count(user => user.Role == AdminRole),
            StaffCount = activeUsers.Count(user => user.Role == StaffRole),
            ActiveUserCount = activeUsers.Count()
        };
    }
}
