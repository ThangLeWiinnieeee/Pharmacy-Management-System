namespace PharmacyManagementSystem.DTO.Output;

public class MedicineBatchDTO
{
    public int Id { get; set; }
    public int MedicineId { get; set; }
    public DateTime ImportDate { get; set; }
    public int ImportQuantity { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public decimal ImportPrice { get; set; }
    public string? Note { get; set; }
}
