namespace PharmacyManagementSystem.DTO.Input;

public class SaveEmployeeDTO
{
    public int? Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Role { get; set; } = "Staff";

    public bool IsActive { get; set; } = true;
}
