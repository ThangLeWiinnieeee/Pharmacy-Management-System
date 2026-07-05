namespace PharmacyManagementSystem.DTO.Output;

/// <summary>Doanh thu của một nhân viên trong một tháng</summary>
public class EmployeeRevenueDTO
{
    public int UserId { get; set; }

    public string FullName { get; set; } = string.Empty;

    public string Username { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;

    public int InvoiceCount { get; set; }

    public decimal Revenue { get; set; }
}
