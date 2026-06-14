using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class InvoiceBLL : IInvoiceBLL
{
    private readonly IInvoiceDAL _invoiceDAL;

    public InvoiceBLL(IInvoiceDAL invoiceDAL)
    {
        _invoiceDAL = invoiceDAL;
    }

    public OperationResultDTO CreateInvoice(CreateInvoiceDTO request)
    {
        // Validate
        if (request.Details.Count == 0)
        {
            return OperationResultDTO.Failure("Hóa đơn phải có ít nhất một mặt hàng.");
        }

        foreach (var item in request.Details)
        {
            if (item.Quantity <= 0)
            {
                return OperationResultDTO.Failure($"Số lượng của '{item.MedicineName}' phải lớn hơn 0.");
            }

            if (item.UnitPrice < 0)
            {
                return OperationResultDTO.Failure($"Đơn giá của '{item.MedicineName}' không hợp lệ.");
            }
        }

        if (request.Discount < 0)
        {
            return OperationResultDTO.Failure("Giảm giá không được âm.");
        }

        var total = request.Details.Sum(d => d.LineTotal);
        if (request.Discount > total)
        {
            return OperationResultDTO.Failure("Giảm giá không được lớn hơn tổng tiền hàng.");
        }

        try
        {
            var invoice = _invoiceDAL.Create(request);
            return OperationResultDTO.Success($"Lập hóa đơn thành công. Mã hóa đơn: {invoice.InvoiceCode}");
        }
        catch
        {
            return OperationResultDTO.Failure("Không thể lưu hóa đơn. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public List<InvoiceDTO> GetAll()
    {
        return _invoiceDAL.GetAll();
    }
}
