using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class MainForm : Form, IDashboardView
{
    private static readonly Color MutedTextColor = Color.FromArgb(102, 102, 102);
    private static readonly Color ErrorTextColor = Color.FromArgb(220, 53, 69);
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    private readonly UserDTO _currentUser;
    private readonly DashboardPresenter _dashboardPresenter;

    public MainForm(UserDTO currentUser)
    {
        _currentUser = currentUser;
        _dashboardPresenter = new DashboardPresenter(this);

        InitializeComponent();
        medicineManagementView.IsAdmin = currentUser.Role == "Admin";
        RegisterNavigationEvents();
        BindCurrentUser();
        ShowDashboardPage();
    }

    public void ShowDashboardStats(DashboardStatsDTO stats)
    {
        labelTotalMedicineValue.Text   = FormatNumber(stats.TotalMedicineTypes);
        labelActiveMedicineValue.Text  = FormatNumber(stats.ActiveMedicineTypes);
        labelStockQuantityValue.Text   = FormatNumber(stats.TotalStockQuantity);
        labelExpiringSoonValue.Text    = FormatNumber(stats.ExpiringSoonMedicineTypes);
        labelLowStockValue.Text        = FormatNumber(stats.LowStockMedicineTypes);
        labelStoppedValue.Text         = FormatNumber(stats.StoppedMedicineTypes);
        labelExpiredValue.Text         = FormatNumber(stats.ExpiredMedicineTypes);
        labelAdminValue.Text           = FormatNumber(stats.AdminCount);
        labelStaffValue.Text           = FormatNumber(stats.StaffCount);
        labelActiveUserValue.Text      = FormatNumber(stats.CustomerCount);
    }

    public void ShowMonthlyRevenue(IReadOnlyList<MonthlyRevenuePointDTO> points, int year)
    {
        var plot = formsPlotRevenue.Plot;
        plot.Clear();

        // Năm hiện tại chỉ hiển thị tới tháng hiện tại; năm trước hiển thị đủ 12 tháng
        var now = DateTime.Today;
        var maxMonth = year < now.Year ? 12 : now.Month;
        var shown = points.Where(p => p.Month <= maxMonth).ToList();

        var accent = ScottPlot.Color.FromHex("#007BFF");
        var bars = shown.Select((p, i) => new ScottPlot.Bar
        {
            Position = i,
            Value = (double)p.Revenue,
            FillColor = accent,
            Label = p.Revenue.ToString("N0", Vi)
        }).ToArray();
        var barPlot = plot.Add.Bars(bars);
        barPlot.ValueLabelStyle.FontSize = 11;
        barPlot.ValueLabelStyle.Bold = true;
        barPlot.ValueLabelStyle.ForeColor = ScottPlot.Color.FromHex("#333333");

        var ticks = shown
            .Select((p, i) => new ScottPlot.Tick(i, $"T{p.Month}"))
            .ToArray();
        plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

        plot.Title($"Tổng doanh thu theo tháng · Năm {year}");
        plot.Axes.Left.Label.Text = "Doanh thu (đ)";

        // Cố định trục: chỉ hiển thị vùng dương từ 0, chừa khoảng trống trên đỉnh cho nhãn số tiền
        var maxRevenue = shown.Count == 0 ? 0 : shown.Max(p => (double)p.Revenue);
        var top = maxRevenue <= 0 ? 1 : maxRevenue * 1.2;
        plot.Axes.SetLimits(-0.6, shown.Count - 0.4, 0, top);

        // Biểu đồ chỉ để xem tổng quan: khóa mọi thao tác kéo/phóng to/thu nhỏ
        formsPlotRevenue.UserInputProcessor.Disable();

        formsPlotRevenue.Refresh();
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
        sideNavigationMenu.InvoiceRequested += (_, _) => ShowInvoiceHistoryPage();
        sideNavigationMenu.CustomerRequested += (_, _) => ShowCustomerPage();
        sideNavigationMenu.RevenueRequested += (_, _) => ShowRevenuePage();
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
        _dashboardPresenter.LoadDashboard();
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

    private void ShowCustomerPage()
    {
        customerManagementView.Reload();
        ShowOnly(customerManagementView);
        labelHeaderTitle.Text = "Quản lý khách hàng";
        labelHeaderSubtitle.Text = "Danh sách khách hàng, thông tin liên hệ và lịch sử mua hàng";
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        Text = "Quản lý khách hàng";
        sideNavigationMenu.SetActiveItem(SideNavigationMenuItem.Customer);
    }

    private void ShowRevenuePage()
    {
        ShowOnly(revenueReportView);
        revenueReportView.Reload();
        labelHeaderTitle.Text = "Doanh thu nhân viên";
        labelHeaderSubtitle.Text = "Doanh thu theo tháng của từng nhân viên trong cửa hàng";
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        Text = "Doanh thu nhân viên";
        sideNavigationMenu.SetActiveItem(SideNavigationMenuItem.Revenue);
    }

    private void ShowInvoiceHistoryPage()
    {
        ShowOnly(invoiceHistoryView);
        labelHeaderTitle.Text = "Lịch sử bán hàng";
        labelHeaderSubtitle.Text = "Tra cứu hóa đơn, chi tiết thuốc đã bán và tổng doanh thu";
        labelHeaderSubtitle.ForeColor = MutedTextColor;
        Text = "Lịch sử bán hàng";
        sideNavigationMenu.SetActiveItem(SideNavigationMenuItem.Invoice);
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
        invoiceHistoryView.Visible = activeControl == invoiceHistoryView;
        customerManagementView.Visible = activeControl == customerManagementView;
        revenueReportView.Visible = activeControl == revenueReportView;
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
