using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class EmployeeManagementView : UserControl, IEmployeeManagementView
{
    private readonly EmployeePresenter _presenter;

    public EmployeeManagementView()
    {
        InitializeComponent();

        _presenter = new EmployeePresenter(this);
        comboStatusFilter.SelectedIndex = 0;
        comboRoleFilter.SelectedIndex = 0;

        Load += (_, _) => _presenter.LoadEmployees();
        textSearchEmployee.TextChanged += (_, _) => _presenter.LoadEmployees();
        comboStatusFilter.SelectedIndexChanged += (_, _) => _presenter.LoadEmployees();
        comboRoleFilter.SelectedIndexChanged += (_, _) => _presenter.LoadEmployees();
        employeesGrid.SelectionChanged += (_, _) => UpdateLockButtonText();
        buttonAddEmployee.Click += (_, _) => _presenter.AddEmployee();
        buttonEditEmployee.Click += (_, _) => _presenter.EditEmployee();
        buttonLockEmployee.Click += (_, _) => _presenter.ToggleEmployeeActive();
    }

    public string SearchKeyword => textSearchEmployee.Text.Trim();

    public string StatusFilter => comboStatusFilter.SelectedItem?.ToString() ?? "Tất cả";

    public string RoleFilter => comboRoleFilter.SelectedItem?.ToString() ?? "Tất cả";

    public int? SelectedEmployeeId
    {
        get
        {
            if (employeesGrid.CurrentRow?.Tag is UserDTO user)
            {
                return user.Id;
            }

            return null;
        }
    }

    public void ShowEmployees(IReadOnlyList<UserDTO> employees)
    {
        employeesGrid.Rows.Clear();

        foreach (var employee in employees)
        {
            var rowIndex = employeesGrid.Rows.Add(
                employee.Username,
                employee.FullName,
                employee.Email,
                employee.Phone,
                employee.Role,
                employee.IsActive ? "Đang hoạt động" : "Đã khóa");

            employeesGrid.Rows[rowIndex].Tag = employee;
        }

        UpdateLockButtonText();
    }

    public SaveEmployeeDTO? RequestEmployeeInput(SaveEmployeeDTO? currentEmployee)
    {
        using var editorForm = new EmployeeEditorForm(currentEmployee);
        return editorForm.ShowDialog(this) == DialogResult.OK
            ? editorForm.EmployeeInput
            : null;
    }

    public bool Confirm(string message)
    {
        return MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    public void ShowMessage(string message)
    {
        MessageBox.Show(this, message, "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Quản lý nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void UpdateLockButtonText()
    {
        if (employeesGrid.CurrentRow?.Tag is not UserDTO user)
        {
            buttonLockEmployee.Text = "Khóa";
            return;
        }

        buttonLockEmployee.Text = user.IsActive ? "Khóa" : "Mở";
    }
}
