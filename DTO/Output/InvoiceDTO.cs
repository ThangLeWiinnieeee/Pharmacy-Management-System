namespace PharmacyManagementSystem.DTO.Output;

public class InvoiceDTO
{
    public int Id { get; set; }

    public string InvoiceCode { get; set; } = string.Empty;

    public string? CustomerName { get; set; }

    public string? CustomerPhone { get; set; }

    public string CreatedByFullName { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }

    public decimal Discount { get; set; }

    public decimal FinalAmount { get; set; }

    public int PointsEarned { get; set; }

    public int PointsUsed { get; set; }

    public string? Note { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public List<InvoiceDetailDTO> Details { get; set; } = [];
}
