namespace PharmacyManagementSystem.Entities;

public class Customer
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Phone { get; set; }

    public string? Address { get; set; }

    /// <summary>Điểm tích lũy hiện có (1 điểm = 1đ khi trừ vào hóa đơn)</summary>
    public int Points { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public List<Invoice> Invoices { get; set; } = [];
}
