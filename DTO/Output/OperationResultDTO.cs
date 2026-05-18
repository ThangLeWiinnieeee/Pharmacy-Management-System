namespace PharmacyManagementSystem.DTO.Output;

public class OperationResultDTO
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public static OperationResultDTO Success(string message)
    {
        return new OperationResultDTO
        {
            IsSuccess = true,
            Message = message
        };
    }

    public static OperationResultDTO Failure(string message)
    {
        return new OperationResultDTO
        {
            IsSuccess = false,
            Message = message
        };
    }
}
