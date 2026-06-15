namespace PharmacyManagementSystem.DTO.Output;

public class DashboardStatsDTO
{
    public int TotalMedicineTypes { get; set; }

    public int ActiveMedicineTypes { get; set; }

    public int TotalStockQuantity { get; set; }

    public int LowStockMedicineTypes { get; set; }

    public int ExpiringSoonMedicineTypes { get; set; }

    public int StoppedMedicineTypes { get; set; }

    public int ExpiredMedicineTypes { get; set; }

    public int AdminCount { get; set; }

    public int StaffCount { get; set; }

    public int CustomerCount { get; set; }
}
