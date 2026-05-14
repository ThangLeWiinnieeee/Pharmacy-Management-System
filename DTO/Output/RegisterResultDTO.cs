namespace PharmacyManagementSystem.DTO.Output;

public class RegisterResultDTO
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public UserDTO? User { get; set; }

    public static RegisterResultDTO Success(string message, UserDTO user)
    {
        return new RegisterResultDTO
        {
            IsSuccess = true,
            Message = message,
            User = user
        };
    }

    public static RegisterResultDTO Failure(string message)
    {
        return new RegisterResultDTO
        {
            IsSuccess = false,
            Message = message
        };
    }
}
