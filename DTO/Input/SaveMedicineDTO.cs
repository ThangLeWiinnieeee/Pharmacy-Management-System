namespace PharmacyManagementSystem.DTO.Input;

public class SaveMedicineDTO
{
    public int? Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public string? Manufacturer { get; set; }

    public decimal ImportPrice { get; set; }

    public decimal SellPrice { get; set; }

    public int Quantity { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;
}
