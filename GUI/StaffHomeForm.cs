using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

public partial class StaffHomeForm : Form
{
    private readonly UserDTO _currentUser;

    public StaffHomeForm(UserDTO currentUser)
    {
        _currentUser = currentUser;
        InitializeComponent();
        BindCurrentUser();
    }

    private void BindCurrentUser()
    {
        labelHeaderSubtitle.Text = $"Xin chào, {_currentUser.FullName}  |  Vai trò: {_currentUser.Role}";
        labelAccount.Text = $"Tài khoản: {_currentUser.Username}";
    }

    private void HandleLogoutClick(object? sender, EventArgs e)
    {
        Logout();
    }

    private void HandleSearchMedicineClick(object? sender, EventArgs e)
    {
        using var form = new MedicineForm();
        form.ShowDialog(this);
    }

    private void HandleCreateInvoiceClick(object? sender, EventArgs e)
    {
        using var form = new InvoiceEditorForm(_currentUser);
        form.ShowDialog(this);
    }

    private void Logout()
    {
        DialogResult = DialogResult.Retry;
        Close();
    }
}
