namespace PharmacyManagementSystem.DTO.Output;

public class LoginResultDTO
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public UserDTO? User { get; set; }

    public static LoginResultDTO Success(string message, UserDTO user)
    {
        return new LoginResultDTO
        {
            IsSuccess = true,
            Message = message,
            User = user
        };
    }

    public static LoginResultDTO Failure(string message)
    {
        return new LoginResultDTO
        {
            IsSuccess = false,
            Message = message
        };
    }
}
