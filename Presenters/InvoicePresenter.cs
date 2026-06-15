using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class InvoicePresenter
{
    private readonly IInvoiceEditorView _view;
    private readonly IInvoiceBLL _invoiceBLL;
    private readonly IMedicineBLL _medicineBLL;
    private readonly ICustomerBLL _customerBLL;
    private readonly int _currentUserId;

    public InvoicePresenter(IInvoiceEditorView view, int currentUserId)
        : this(view, currentUserId, new InvoiceBLL(new InvoiceDAL()), new MedicineBLL(new MedicineDAL()), new CustomerBLL())
    {
    }

    public InvoicePresenter(IInvoiceEditorView view, int currentUserId, IInvoiceBLL invoiceBLL, IMedicineBLL medicineBLL, ICustomerBLL customerBLL)
    {
        _view = view;
        _currentUserId = currentUserId;
        _invoiceBLL = invoiceBLL;
        _medicineBLL = medicineBLL;
        _customerBLL = customerBLL;
    }

    /// <summary>Xử lý khi người dùng mở dialog chọn thuốc</summary>
    public void AddMedicineToCart()
    {
        var items = _view.RequestSelectMedicines();
        if (items is null || items.Count == 0)
        {
            return;
        }

        // View tự merge/add vào _cartItems bên trong RequestSelectMedicines
        // Presenter chỉ cần trigger refresh tổng tiền
        RefreshTotals();
    }

    /// <summary>Tính lại tổng tiền và cập nhật UI</summary>
    public void RefreshTotals()
    {
        var items = _view.CartItems;
        var total = items.Sum(d => d.LineTotal);
        var discount = _view.Discount;
        var final = total - discount;
        if (final < 0)
        {
            final = 0;
        }

        _view.RefreshTotals(total, discount, final);
    }

    /// <summary>Xử lý lưu hóa đơn</summary>
    public void SaveInvoice()
    {
        if (_view.CartItems.Count == 0)
        {
            _view.ShowError("Chưa có thuốc nào trong hóa đơn.\nVui lòng thêm ít nhất 1 loại thuốc trước khi lưu.");
            return;
        }

        if (!string.IsNullOrWhiteSpace(_view.CustomerPhone) && string.IsNullOrWhiteSpace(_view.CustomerName))
        {
            _view.ShowError("Đã nhập SĐT nhưng khách hàng chưa được xác nhận.\nHãy nhấn 'Tìm' để tra cứu, tạo khách hàng mới, hoặc xóa SĐT để bán cho khách lẻ.");
            return;
        }

        if (!_view.Confirm("Xác nhận lập hóa đơn?"))
        {
            return;
        }

        var request = new CreateInvoiceDTO
        {
            CreatedByUserId = _currentUserId,
            CustomerName = _view.CustomerName,
            CustomerPhone = _view.CustomerPhone,
            Discount = _view.Discount,
            Note = _view.Note,
            Details = _view.CartItems.ToList()
        };

        var result = _invoiceBLL.CreateInvoice(request);

        if (result.IsSuccess)
        {
            var newCode = "HD" + DateTime.Now.ToString("yyMMddHHmmss");
            _view.ResetForm(newCode);
            _view.ShowMessage(result.Message);
        }
        else
        {
            _view.ShowError(result.Message);
        }
    }

    /// <summary>Tra cứu khách hàng theo SĐT và thông báo kết quả lên View</summary>
    public void LookupCustomer(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
        {
            _view.ClearCustomerStatus();
            return;
        }

        var result = _customerBLL.LookupByPhone(phone.Trim());
        if (result is not null)
            _view.ShowCustomerFound(result);
        else
            _view.ShowCustomerNotFound(phone.Trim());
    }

    /// <summary>Lấy danh sách thuốc đang kinh doanh để chọn</summary>
    public IReadOnlyList<MedicineDTO> GetAvailableMedicines()
    {
        return _medicineBLL.GetMedicines(new DTO.Input.MedicineQueryDTO
        {
            Keyword = string.Empty,
            StatusFilter = "Đang kinh doanh"
        });
    }
}
