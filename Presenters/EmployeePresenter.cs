using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class EmployeePresenter
{
    private readonly IEmployeeBLL _employeeBLL;
    private readonly IEmployeeManagementView _view;

    public EmployeePresenter(IEmployeeManagementView view)
        : this(view, new EmployeeBLL(new UserDAL()))
    {
    }

    public EmployeePresenter(IEmployeeManagementView view, IEmployeeBLL employeeBLL)
    {
        _view = view;
        _employeeBLL = employeeBLL;
    }

    public void LoadEmployees()
    {
        try
        {
            _view.ShowEmployees(_employeeBLL.GetEmployees(CreateQuery()));
        }
        catch
        {
            _view.ShowError("Không thể tải danh sách nhân viên. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public void AddEmployee()
    {
        var request = _view.RequestEmployeeInput(null);
        if (request is null)
        {
            return;
        }

        SaveEmployee(request);
    }

    public void EditEmployee()
    {
        var selectedId = _view.SelectedEmployeeId;
        if (!selectedId.HasValue)
        {
            _view.ShowError("Vui lòng chọn nhân viên cần sửa.");
            return;
        }

        var currentEmployee = _employeeBLL.GetEmployeeForEdit(selectedId.Value);
        if (currentEmployee is null)
        {
            _view.ShowError("Không tìm thấy nhân viên cần sửa.");
            LoadEmployees();
            return;
        }

        var request = _view.RequestEmployeeInput(currentEmployee);
        if (request is null)
        {
            return;
        }

        SaveEmployee(request);
    }

    public void ToggleEmployeeActive()
    {
        var selectedId = _view.SelectedEmployeeId;
        if (!selectedId.HasValue)
        {
            _view.ShowError("Vui lòng chọn nhân viên cần khóa hoặc mở khóa.");
            return;
        }

        if (!_view.Confirm("Bạn có chắc muốn đổi trạng thái tài khoản nhân viên được chọn?"))
        {
            return;
        }

        var result = _employeeBLL.ToggleEmployeeActive(selectedId.Value);
        ShowResult(result.Message, result.IsSuccess);
    }

    private void SaveEmployee(SaveEmployeeDTO request)
    {
        var result = _employeeBLL.SaveEmployee(request);
        ShowResult(result.Message, result.IsSuccess);
    }

    private void ShowResult(string message, bool isSuccess)
    {
        if (isSuccess)
        {
            _view.ShowMessage(message);
            LoadEmployees();
            return;
        }

        _view.ShowError(message);
    }

    private EmployeeQueryDTO CreateQuery()
    {
        return new EmployeeQueryDTO
        {
            Keyword = _view.SearchKeyword,
            StatusFilter = _view.StatusFilter,
            RoleFilter = _view.RoleFilter
        };
    }
}
