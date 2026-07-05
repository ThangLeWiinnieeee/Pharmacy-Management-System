namespace PharmacyManagementSystem.DTO.Output;

public class OperationResultDTO
{
    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    /// <summary>Mã hóa đơn vừa tạo (dùng để in), null nếu thao tác không tạo hóa đơn</summary>
    public string? InvoiceCode { get; set; }

    public static OperationResultDTO Success(string message, string? invoiceCode = null)
    {
        return new OperationResultDTO
        {
            IsSuccess = true,
            Message = message,
            InvoiceCode = invoiceCode
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
