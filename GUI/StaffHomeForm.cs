using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

public class StaffHomeForm : Form
{
    private readonly UserDTO _currentUser;

    public StaffHomeForm(UserDTO currentUser)
    {
        _currentUser = currentUser;
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        var headerPanel = CreateHeaderPanel();
        var contentPanel = CreateContentPanel();

        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(1000, 640);
        Controls.Add(contentPanel);
        Controls.Add(headerPanel);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "StaffHomeForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Khu vực nhân viên";
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
            Text = "Khu vực nhân viên"
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
            Location = new Point(846, 27),
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

        var summaryPanel = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 18,
            BorderSize = 1,
            Location = new Point(32, 32),
            Size = new Size(936, 132)
        };

        var titleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(28, 24),
            Text = "Quầy làm việc"
        };

        var accountLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(102, 102, 102),
            Location = new Point(31, 70),
            Text = $"Tài khoản: {_currentUser.Username}"
        };

        summaryPanel.Controls.Add(titleLabel);
        summaryPanel.Controls.Add(accountLabel);

        var actionPanel = new Panel
        {
            BackColor = Color.FromArgb(248, 249, 250),
            Location = new Point(32, 196),
            Size = new Size(936, 296)
        };

        actionPanel.Controls.Add(CreateActionCard("Tra cứu thuốc", "Xem thông tin thuốc", Color.FromArgb(0, 123, 255), new Point(0, 0)));
        actionPanel.Controls.Add(CreateActionCard("Lập hóa đơn", "Tạo giao dịch bán hàng", Color.FromArgb(40, 167, 69), new Point(318, 0)));
        actionPanel.Controls.Add(CreateActionCard("Lịch sử bán hàng", "Theo dõi hóa đơn", Color.FromArgb(23, 162, 184), new Point(636, 0)));

        contentPanel.Controls.Add(actionPanel);
        contentPanel.Controls.Add(summaryPanel);

        return contentPanel;
    }

    private static RoundedPanel CreateActionCard(string title, string description, Color accentColor, Point location)
    {
        var card = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 16,
            BorderSize = 1,
            Location = location,
            Size = new Size(300, 184)
        };

        var accentPanel = new Panel
        {
            BackColor = accentColor,
            Location = new Point(24, 28),
            Size = new Size(52, 6)
        };

        var titleLabel = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(22, 52),
            Text = title
        };

        var descriptionLabel = new Label
        {
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(102, 102, 102),
            Location = new Point(24, 92),
            Size = new Size(246, 28),
            Text = description
        };

        var openButton = new RoundedButton
        {
            BackColor = accentColor,
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = ControlPaint.Dark(accentColor, 0.08F),
            Location = new Point(24, 128),
            Size = new Size(132, 38),
            Text = "Mở",
            UseVisualStyleBackColor = false
        };

        card.Controls.Add(accentPanel);
        card.Controls.Add(titleLabel);
        card.Controls.Add(descriptionLabel);
        card.Controls.Add(openButton);

        return card;
    }
}
