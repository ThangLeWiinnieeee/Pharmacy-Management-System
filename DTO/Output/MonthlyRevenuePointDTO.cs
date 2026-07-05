namespace PharmacyManagementSystem.DTO.Output;

/// <summary>Tổng doanh thu của một tháng trong năm (cho biểu đồ dashboard)</summary>
public class MonthlyRevenuePointDTO
{
    public int Month { get; set; }

    public decimal Revenue { get; set; }
}
