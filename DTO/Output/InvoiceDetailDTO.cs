namespace PharmacyManagementSystem.DTO.Output;

public class InvoiceDetailDTO
{
    public int Id { get; set; }

    public int MedicineId { get; set; }

    public string MedicineCode { get; set; } = string.Empty;

    public string MedicineName { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}
