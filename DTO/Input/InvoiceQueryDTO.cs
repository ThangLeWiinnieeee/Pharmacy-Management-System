namespace PharmacyManagementSystem.DTO.Input;

public class InvoiceQueryDTO
{
    public string Keyword { get; set; } = string.Empty;

    public string StatusFilter { get; set; } = "Tất cả";

    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }
}
