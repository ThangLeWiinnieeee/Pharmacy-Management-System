namespace PharmacyManagementSystem;

public enum SideNavigationMenuItem
{
    Dashboard,
    Medicine,
    Employee,
    Invoice,
    Report
}

public class SideNavigationMenu : UserControl
{
    private static readonly Color NavigationActiveBackColor = Color.FromArgb(0, 123, 255);
    private static readonly Color NavigationHoverBackColor = Color.FromArgb(234, 244, 255);
    private static readonly Color NavigationPressedBackColor = Color.FromArgb(218, 236, 255);
    private static readonly Color NavigationBorderColor = Color.FromArgb(224, 229, 235);
    private static readonly Color TextColor = Color.FromArgb(51, 51, 51);
    private static readonly Color MutedTextColor = Color.FromArgb(102, 102, 102);

    private readonly Label _userNameLabel;
    private readonly Label _userRoleLabel;
    private readonly RoundedButton _dashboardButton;
    private readonly RoundedButton _medicineButton;
    private readonly RoundedButton _employeeButton;
    private readonly RoundedButton _invoiceButton;
    private readonly RoundedButton _reportButton;
    private readonly RoundedButton _logoutButton;
    private readonly Dictionary<SideNavigationMenuItem, RoundedButton> _navigationButtons;

    private SideNavigationMenuItem _activeItem = SideNavigationMenuItem.Dashboard;

    public SideNavigationMenu()
    {
        BackColor = Color.White;
        Dock = DockStyle.Left;
        MinimumSize = new Size(248, 0);
        Padding = new Padding(18, 22, 18, 18);
        Size = new Size(248, 760);

        var brandTitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(0, 86, 179),
            Location = new Point(18, 22),
            Name = "labelBrandTitle",
            Text = "Pharmacy"
        };

        var brandSubtitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = MutedTextColor,
            Location = new Point(20, 58),
            Name = "labelBrandSubtitle",
            Text = "Quản trị nhà thuốc"
        };

        var navigationTitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 8.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(132, 145, 160),
            Location = new Point(20, 104),
            Name = "labelNavigationTitle",
            Text = "ĐIỀU HƯỚNG"
        };

        _dashboardButton = CreateNavigationButton("Tổng quan", new Point(18, 134), 3, SideNavigationMenuItem.Dashboard);
        _medicineButton = CreateNavigationButton("Quản lý thuốc", new Point(18, 186), 4, SideNavigationMenuItem.Medicine);
        _employeeButton = CreateNavigationButton("Quản lý nhân viên", new Point(18, 238), 5, SideNavigationMenuItem.Employee);
        _invoiceButton = CreateNavigationButton("Hóa đơn", new Point(18, 290), 6, SideNavigationMenuItem.Invoice);
        _reportButton = CreateNavigationButton("Báo cáo", new Point(18, 342), 7, SideNavigationMenuItem.Report);

        _logoutButton = new RoundedButton
        {
            BackColor = Color.FromArgb(220, 53, 69),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(201, 48, 62),
            Location = new Point(0, 78),
            Name = "buttonLogout",
            PressedBackColor = Color.FromArgb(188, 44, 58),
            Size = new Size(212, 40),
            TabIndex = 8,
            Text = "Đăng xuất",
            UseVisualStyleBackColor = false
        };
        _logoutButton.FlatAppearance.BorderSize = 0;
        _logoutButton.Click += (_, _) => LogoutRequested?.Invoke(this, EventArgs.Empty);

        var footerPanel = new Panel
        {
            Dock = DockStyle.Bottom,
            Location = new Point(18, 604),
            Name = "panelSidebarFooter",
            Size = new Size(212, 138)
        };

        _userNameLabel = new Label
        {
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = TextColor,
            Location = new Point(0, 18),
            Name = "labelSidebarUserName",
            Size = new Size(212, 22),
            Text = "Admin"
        };

        _userRoleLabel = new Label
        {
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = MutedTextColor,
            Location = new Point(0, 44),
            Name = "labelSidebarUserRole",
            Size = new Size(212, 22),
            Text = "Admin | admin"
        };

        footerPanel.Controls.Add(_userNameLabel);
        footerPanel.Controls.Add(_userRoleLabel);
        footerPanel.Controls.Add(_logoutButton);

        Controls.Add(footerPanel);
        Controls.Add(_reportButton);
        Controls.Add(_invoiceButton);
        Controls.Add(_employeeButton);
        Controls.Add(_medicineButton);
        Controls.Add(_dashboardButton);
        Controls.Add(navigationTitleLabel);
        Controls.Add(brandSubtitleLabel);
        Controls.Add(brandTitleLabel);

        _navigationButtons = new Dictionary<SideNavigationMenuItem, RoundedButton>
        {
            [SideNavigationMenuItem.Dashboard] = _dashboardButton,
            [SideNavigationMenuItem.Medicine] = _medicineButton,
            [SideNavigationMenuItem.Employee] = _employeeButton,
            [SideNavigationMenuItem.Invoice] = _invoiceButton,
            [SideNavigationMenuItem.Report] = _reportButton
        };

        foreach (var button in _navigationButtons.Values)
        {
            button.MouseLeave += (_, _) => ApplyNavigationButtonStyles();
        }

        SetActiveItem(SideNavigationMenuItem.Dashboard);
    }

    public event EventHandler? DashboardRequested;

    public event EventHandler? MedicineRequested;

    public event EventHandler? EmployeeRequested;

    public event EventHandler? InvoiceRequested;

    public event EventHandler? ReportRequested;

    public event EventHandler? LogoutRequested;

    public void SetCurrentUser(string fullName, string role, string username)
    {
        _userNameLabel.Text = fullName;
        _userRoleLabel.Text = $"{role} | {username}";
    }

    public void SetActiveItem(SideNavigationMenuItem item)
    {
        _activeItem = item;
        ApplyNavigationButtonStyles();
    }

    private RoundedButton CreateNavigationButton(string text, Point location, int tabIndex, SideNavigationMenuItem item)
    {
        var button = new RoundedButton
        {
            BackColor = Color.White,
            BorderColor = NavigationBorderColor,
            BorderRadius = 12,
            BorderSize = 1,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = TextColor,
            HoverBackColor = NavigationHoverBackColor,
            Location = location,
            Name = $"nav{item}Button",
            Padding = new Padding(16, 0, 0, 0),
            PressedBackColor = NavigationPressedBackColor,
            Size = new Size(212, 44),
            TabIndex = tabIndex,
            Text = text,
            TextAlign = ContentAlignment.MiddleLeft,
            UseVisualStyleBackColor = false
        };

        button.FlatAppearance.BorderSize = 0;
        button.Click += (_, _) => RequestNavigation(item);
        return button;
    }

    private void RequestNavigation(SideNavigationMenuItem item)
    {
        switch (item)
        {
            case SideNavigationMenuItem.Dashboard:
                DashboardRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SideNavigationMenuItem.Medicine:
                MedicineRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SideNavigationMenuItem.Employee:
                EmployeeRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SideNavigationMenuItem.Invoice:
                InvoiceRequested?.Invoke(this, EventArgs.Empty);
                break;
            case SideNavigationMenuItem.Report:
                ReportRequested?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    private void ApplyNavigationButtonStyles()
    {
        foreach (var (item, button) in _navigationButtons)
        {
            var isActive = item == _activeItem;
            button.BackColor = isActive ? NavigationActiveBackColor : Color.White;
            button.ForeColor = isActive ? Color.White : TextColor;
            button.BorderColor = isActive ? Color.Transparent : NavigationBorderColor;
            button.BorderSize = isActive ? 0 : 1;
            button.HoverBackColor = isActive ? NavigationActiveBackColor : NavigationHoverBackColor;
            button.PressedBackColor = isActive ? NavigationActiveBackColor : NavigationPressedBackColor;
        }
    }
}
