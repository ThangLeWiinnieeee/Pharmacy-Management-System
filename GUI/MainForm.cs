using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public class MainForm : Form, IDashboardView
{
    private readonly UserDTO _currentUser;
    private readonly DashboardPresenter _dashboardPresenter;
    private readonly Label _totalMedicineValueLabel = CreateValueLabel();
    private readonly Label _activeMedicineValueLabel = CreateValueLabel();
    private readonly Label _stockQuantityValueLabel = CreateValueLabel();
    private readonly Label _lowStockValueLabel = CreateValueLabel();
    private readonly Label _expiringSoonValueLabel = CreateValueLabel();
    private readonly Label _adminValueLabel = CreateValueLabel();
    private readonly Label _staffValueLabel = CreateValueLabel();
    private readonly Label _activeUserValueLabel = CreateValueLabel();
    private readonly Label _statusLabel = new();

    public MainForm(UserDTO currentUser)
    {
        _currentUser = currentUser;
        _dashboardPresenter = new DashboardPresenter(this);

        InitializeComponent();
        Load += (_, _) => _dashboardPresenter.LoadDashboard();
    }

    public void ShowDashboardStats(DashboardStatsDTO stats)
    {
        _totalMedicineValueLabel.Text = FormatNumber(stats.TotalMedicineTypes);
        _activeMedicineValueLabel.Text = FormatNumber(stats.ActiveMedicineTypes);
        _stockQuantityValueLabel.Text = FormatNumber(stats.TotalStockQuantity);
        _lowStockValueLabel.Text = FormatNumber(stats.LowStockMedicineTypes);
        _expiringSoonValueLabel.Text = FormatNumber(stats.ExpiringSoonMedicineTypes);
        _adminValueLabel.Text = FormatNumber(stats.AdminCount);
        _staffValueLabel.Text = FormatNumber(stats.StaffCount);
        _activeUserValueLabel.Text = FormatNumber(stats.ActiveUserCount);
        _statusLabel.Text = $"Cập nhật lúc {DateTime.Now:HH:mm dd/MM/yyyy}";
        _statusLabel.ForeColor = Color.FromArgb(102, 102, 102);
    }

    public void ShowDashboardError(string message)
    {
        _statusLabel.Text = message;
        _statusLabel.ForeColor = Color.FromArgb(220, 53, 69);
    }

    private void InitializeComponent()
    {
        var headerPanel = CreateHeaderPanel();
        var contentPanel = CreateContentPanel();

        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(1100, 720);
        Controls.Add(contentPanel);
        Controls.Add(headerPanel);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dashboard";
    }

    private Panel CreateHeaderPanel()
    {
        var headerPanel = new Panel
        {
            BackColor = Color.FromArgb(0, 86, 179),
            Dock = DockStyle.Top,
            Height = 92,
            Padding = new Padding(28, 18, 28, 18)
        };

        var titleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            Location = new Point(28, 16),
            Text = "Dashboard"
        };

        var subtitleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(224, 239, 255),
            Location = new Point(31, 54),
            Text = $"Xin chào, {_currentUser.FullName}  |  Vai trò: {_currentUser.Role}"
        };

        var closeButton = new RoundedButton
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            BackColor = Color.FromArgb(220, 53, 69),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(200, 35, 51),
            Location = new Point(946, 27),
            Size = new Size(126, 38),
            Text = "Thoát",
            UseVisualStyleBackColor = false
        };
        closeButton.Click += (_, _) => Close();
        CancelButton = closeButton;

        headerPanel.Controls.Add(titleLabel);
        headerPanel.Controls.Add(subtitleLabel);
        headerPanel.Controls.Add(closeButton);

        return headerPanel;
    }

    private Panel CreateContentPanel()
    {
        var contentPanel = new Panel
        {
            BackColor = Color.FromArgb(248, 249, 250),
            Dock = DockStyle.Fill,
            Padding = new Padding(32)
        };

        var summaryPanel = CreateSummaryPanel();
        var statsPanel = CreateStatsPanel();

        contentPanel.Controls.Add(statsPanel);
        contentPanel.Controls.Add(summaryPanel);

        return contentPanel;
    }

    private RoundedPanel CreateSummaryPanel()
    {
        var summaryPanel = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 18,
            BorderSize = 1,
            Location = new Point(32, 32),
            Size = new Size(1036, 128)
        };

        var titleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(28, 24),
            Text = "Tổng quan nhà thuốc"
        };

        var accountLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(102, 102, 102),
            Location = new Point(31, 68),
            Text = $"Tài khoản: {_currentUser.Username}"
        };

        _statusLabel.AutoSize = true;
        _statusLabel.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _statusLabel.ForeColor = Color.FromArgb(102, 102, 102);
        _statusLabel.Location = new Point(31, 94);
        _statusLabel.Text = "Đang tải dữ liệu...";

        summaryPanel.Controls.Add(titleLabel);
        summaryPanel.Controls.Add(accountLabel);
        summaryPanel.Controls.Add(_statusLabel);

        return summaryPanel;
    }

    private Panel CreateStatsPanel()
    {
        var statsPanel = new Panel
        {
            BackColor = Color.FromArgb(248, 249, 250),
            Location = new Point(32, 184),
            Size = new Size(1036, 456)
        };

        var cards = new[]
        {
            CreateStatCard("Loại thuốc", _totalMedicineValueLabel, "Tất cả mã thuốc", Color.FromArgb(0, 123, 255), new Point(0, 0)),
            CreateStatCard("Đang kinh doanh", _activeMedicineValueLabel, "Mã thuốc còn hiệu lực", Color.FromArgb(40, 167, 69), new Point(264, 0)),
            CreateStatCard("Tổng tồn kho", _stockQuantityValueLabel, "Số lượng thuốc hiện có", Color.FromArgb(23, 162, 184), new Point(528, 0)),
            CreateStatCard("Sắp hết hàng", _lowStockValueLabel, "Tồn kho từ 10 trở xuống", Color.FromArgb(255, 193, 7), new Point(792, 0)),
            CreateStatCard("Sắp hết hạn", _expiringSoonValueLabel, "Hạn dùng trong 30 ngày", Color.FromArgb(220, 53, 69), new Point(0, 196)),
            CreateStatCard("Quản trị viên", _adminValueLabel, "Tài khoản Admin đang hoạt động", Color.FromArgb(111, 66, 193), new Point(264, 196)),
            CreateStatCard("Nhân viên", _staffValueLabel, "Tài khoản Staff đang hoạt động", Color.FromArgb(0, 86, 179), new Point(528, 196)),
            CreateStatCard("Người dùng", _activeUserValueLabel, "Tài khoản đang hoạt động", Color.FromArgb(52, 58, 64), new Point(792, 196))
        };

        statsPanel.Controls.AddRange(cards);

        return statsPanel;
    }

    private static RoundedPanel CreateStatCard(
        string title,
        Label valueLabel,
        string description,
        Color accentColor,
        Point location)
    {
        var card = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 16,
            BorderSize = 1,
            Location = location,
            Size = new Size(244, 164)
        };

        var accentPanel = new Panel
        {
            BackColor = accentColor,
            Location = new Point(22, 24),
            Size = new Size(44, 6)
        };

        var titleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(22, 42),
            Text = title
        };

        valueLabel.Location = new Point(20, 70);

        var descriptionLabel = new Label
        {
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(102, 102, 102),
            Location = new Point(23, 124),
            Size = new Size(196, 24),
            Text = description
        };

        card.Controls.Add(accentPanel);
        card.Controls.Add(titleLabel);
        card.Controls.Add(valueLabel);
        card.Controls.Add(descriptionLabel);

        return card;
    }

    private static Label CreateValueLabel()
    {
        return new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Text = "0"
        };
    }

    private static string FormatNumber(int value)
    {
        return value.ToString("N0", CultureInfo.GetCultureInfo("vi-VN"));
    }
}
