using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class CustomerManagementPresenter
{
    private readonly ICustomerBLL _bll;
    private readonly ICustomerManagementView _view;

    public CustomerManagementPresenter(ICustomerManagementView view)
        : this(view, new CustomerBLL(new CustomerDAL())) { }

    public CustomerManagementPresenter(ICustomerManagementView view, ICustomerBLL bll)
    {
        _view = view;
        _bll = bll;
    }

    public void LoadCustomers()
    {
        try
        {
            _view.ShowCustomers(_bll.GetAll(_view.SearchKeyword));
        }
        catch
        {
            _view.ShowError("Không thể tải danh sách khách hàng. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public void AddCustomer()
    {
        if (_view.RequestCustomerAdd())
            LoadCustomers();
    }

    public void EditCustomer()
    {
        var customer = _view.SelectedCustomer;
        if (customer is null)
        {
            _view.ShowError("Vui lòng chọn khách hàng cần sửa.");
            return;
        }

        if (_view.RequestCustomerEdit(customer))
            LoadCustomers();
    }

    public void DeleteCustomer()
    {
        var customer = _view.SelectedCustomer;
        if (customer is null)
        {
            _view.ShowError("Vui lòng chọn khách hàng cần xóa.");
            return;
        }

        if (customer.InvoiceCount > 0)
        {
            _view.ShowError($"Không thể xóa khách hàng '{customer.Name}' vì còn {customer.InvoiceCount} hóa đơn liên quan.");
            return;
        }

        if (!_view.Confirm($"Bạn có chắc muốn xóa khách hàng '{customer.Name}'?"))
            return;

        try
        {
            _bll.DeleteCustomer(customer.Id);
            _view.ShowMessage("Đã xóa khách hàng thành công.");
            LoadCustomers();
        }
        catch
        {
            _view.ShowError("Không thể xóa khách hàng. Vui lòng thử lại.");
        }
    }
}
