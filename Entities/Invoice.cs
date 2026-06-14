namespace PharmacyManagementSystem.Entities;

public class Invoice
{
    public int Id { get; set; }

    public string InvoiceCode { get; set; } = string.Empty;

    public int? CustomerId { get; set; }

    /// <summary>Tên khách hàng snapshot tại thời điểm lập hóa đơn</summary>
    public string? CustomerName { get; set; }

    /// <summary>SĐT khách hàng snapshot tại thời điểm lập hóa đơn</summary>
    public string? CustomerPhone { get; set; }

    public int CreatedByUserId { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal Discount { get; set; }

    public decimal FinalAmount { get; set; }

    public string? Note { get; set; }

    /// <summary>Trạng thái: Completed, Cancelled</summary>
    public string Status { get; set; } = "Completed";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation
    public Customer? Customer { get; set; }

    public User? CreatedByUser { get; set; }

    public List<InvoiceDetail> Details { get; set; } = [];
}
