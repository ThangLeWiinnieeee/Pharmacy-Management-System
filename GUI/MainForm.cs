using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class MainForm : Form, IDashboardView
{
    private readonly UserDTO _currentUser;
    private readonly DashboardPresenter _dashboardPresenter;

    public MainForm(UserDTO currentUser)
    {
        _currentUser = currentUser;
        _dashboardPresenter = new DashboardPresenter(this);

        InitializeComponent();
        BindCurrentUser();
        Load += (_, _) => _dashboardPresenter.LoadDashboard();
    }

    public void ShowDashboardStats(DashboardStatsDTO stats)
    {
        labelTotalMedicineValue.Text = FormatNumber(stats.TotalMedicineTypes);
        labelActiveMedicineValue.Text = FormatNumber(stats.ActiveMedicineTypes);
        labelStockQuantityValue.Text = FormatNumber(stats.TotalStockQuantity);
        labelLowStockValue.Text = FormatNumber(stats.LowStockMedicineTypes);
        labelExpiringSoonValue.Text = FormatNumber(stats.ExpiringSoonMedicineTypes);
        labelAdminValue.Text = FormatNumber(stats.AdminCount);
        labelStaffValue.Text = FormatNumber(stats.StaffCount);
        labelActiveUserValue.Text = FormatNumber(stats.ActiveUserCount);
        labelStatus.Text = $"Cập nhật lúc {DateTime.Now:HH:mm dd/MM/yyyy}";
        labelStatus.ForeColor = Color.FromArgb(102, 102, 102);
    }

    public void ShowDashboardError(string message)
    {
        labelStatus.Text = message;
        labelStatus.ForeColor = Color.FromArgb(220, 53, 69);
    }

    private void BindCurrentUser()
    {
        labelHeaderSubtitle.Text = $"Xin chào, {_currentUser.FullName}  |  Vai trò: {_currentUser.Role}";
        labelAccount.Text = $"Tài khoản: {_currentUser.Username}";
    }

    private static string FormatNumber(int value)
    {
        return value.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
    }

    private void HandleLogoutClick(object? sender, EventArgs e)
    {
        Logout();
    }

    private void Logout()
    {
        DialogResult = DialogResult.Retry;
        Close();
    }
}
