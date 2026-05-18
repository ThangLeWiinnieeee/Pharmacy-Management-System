namespace PharmacyManagementSystem.DTO.Input;

public class MedicineQueryDTO
{
    public string Keyword { get; set; } = string.Empty;

    public string StatusFilter { get; set; } = "Tất cả";
}
