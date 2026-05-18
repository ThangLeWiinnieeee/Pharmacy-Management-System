using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class MainForm : Form, IDashboardView
{
    private static readonly Color MutedTextColor = Color.FromArgb(102, 102, 102);
    private static readonly Color ErrorTextColor = Color.FromArgb(220, 53, 69);

    private readonly UserDTO _currentUser;
    private readonly DashboardPresenter _dashboardPresenter;

    public MainForm(UserDTO currentUser)
    {
        _currentUser = currentUser;
        _dashboardPresenter = new DashboardPresenter(this);

        InitializeComponent();
        RegisterNavigationEvents();
        BindCurrentUser();
        ShowDashboardPage();
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
    }

    public void ShowDashboardError(string message)
    {
        labelHeaderSubtitle.Text = message;
        labelHeaderSubtitle.ForeColor = ErrorTextColor;
    }

    private void RegisterNavigationEvents()
    {
        sideNavigationMenu.DashboardRequested += (_, _) => ShowDashboardPage();
        sideNavigationMenu.MedicineRequested += (_, _) => ShowMedicinePage();
        sideNavigationMenu.EmployeeRequested += (_, _) => ShowEmployeePage();
        sideNavigationMenu.InvoiceRequested += (_, _) => ShowPlaceholderPage(
            SideNavigationMenuItem.Invoice,
            "Hóa đơn",
            "Khu vực lập hóa đơn, theo dõi giao dịch bán hàng và lịch sử thanh toán.");
        sideNavigationMenu.ReportRequested += (_, _) => ShowPlaceholderPage(
            SideNavigationMenuItem.Report,
            "Báo cáo",
            "Khu vực tổng hợp báo cáo doanh thu, tồn kho và hiệu quả vận hành.");
        sideNavigationMenu.LogoutRequested += (_, _) => Logout();
    }

    private void BindCurrentUser()
    {
        sideNavigationMenu.SetCurrentUser(_currentUser.FullName, _currentUser.Role, _currentUser.Username);
    }

    private void ShowDashboardPage()
    {
        ShowOnly(panelDashboard);
        labelHeaderTitle.Text = "Tổng quan";
        labelHeaderSubtitle.Text = "Theo dõi nhanh tình trạng thuốc và tài khoản hệ thống";
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        Text = "Dashboard";
        sideNavigationMenu.SetActiveItem(SideNavigationMenuItem.Dashboard);
    }

    private void ShowMedicinePage()
    {
        ShowOnly(medicineManagementView);
        labelHeaderTitle.Text = "Quản lý thuốc";
        labelHeaderSubtitle.Text = "Danh mục thuốc, tồn kho, giá bán và hạn dùng";
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        Text = "Quản lý thuốc";
        sideNavigationMenu.SetActiveItem(SideNavigationMenuItem.Medicine);
    }

    private void ShowEmployeePage()
    {
        ShowOnly(employeeManagementView);
        labelHeaderTitle.Text = "Quản lý nhân viên";
        labelHeaderSubtitle.Text = "Tài khoản, vai trò và trạng thái hoạt động của nhân viên";
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        Text = "Quản lý nhân viên";
        sideNavigationMenu.SetActiveItem(SideNavigationMenuItem.Employee);
    }

    private void ShowPlaceholderPage(SideNavigationMenuItem selectedItem, string title, string description)
    {
        ShowOnly(panelPlaceholder);
        labelHeaderTitle.Text = title;
        labelHeaderSubtitle.Text = description;
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        labelPlaceholderTitle.Text = title;
        labelPlaceholderDescription.Text = "Chức năng đang được chuẩn bị. Sidebar đã sẵn sàng để gắn form nghiệp vụ khi module được triển khai.";
        Text = title;
        sideNavigationMenu.SetActiveItem(selectedItem);
    }

    private void ShowOnly(Control activeControl)
    {
        panelDashboard.Visible = activeControl == panelDashboard;
        medicineManagementView.Visible = activeControl == medicineManagementView;
        employeeManagementView.Visible = activeControl == employeeManagementView;
        panelPlaceholder.Visible = activeControl == panelPlaceholder;
    }

    private static string FormatNumber(int value)
    {
        return value.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
    }

    private void Logout()
    {
        DialogResult = DialogResult.Retry;
        Close();
    }
}
