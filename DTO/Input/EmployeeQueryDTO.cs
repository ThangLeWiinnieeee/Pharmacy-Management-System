namespace PharmacyManagementSystem.DTO.Input;

public class EmployeeQueryDTO
{
    public string Keyword { get; set; } = string.Empty;

    public string StatusFilter { get; set; } = "Tất cả";

    public string RoleFilter { get; set; } = "Tất cả";
}
