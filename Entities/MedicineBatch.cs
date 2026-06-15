namespace PharmacyManagementSystem.Entities;

public class MedicineBatch
{
    public int Id { get; set; }
    public int MedicineId { get; set; }
    public Medicine Medicine { get; set; } = null!;
    public DateTime ImportDate { get; set; } = DateTime.Now;
    public int ImportQuantity { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public decimal ImportPrice { get; set; }
    public string? Note { get; set; }
}
