namespace PharmacyManagementSystem.DTO.Output;

public class CustomerLookupDTO
{
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public decimal TotalPurchases { get; set; }
    public int InvoiceCount { get; set; }
    public int Points { get; set; }
}
