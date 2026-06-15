using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem;

public class EmployeeEditorForm : Form
{
    private readonly SaveEmployeeDTO? _currentEmployee;
    private readonly RoundedTextBox _usernameTextBox = new();
    private readonly RoundedTextBox _passwordTextBox = new();
    private readonly RoundedTextBox _fullNameTextBox = new();
    private readonly RoundedTextBox _emailTextBox = new();
    private readonly RoundedTextBox _phoneTextBox = new();
    private readonly ComboBox _roleComboBox = new();
    private readonly CheckBox _activeCheckBox = new();

    public EmployeeEditorForm(SaveEmployeeDTO? currentEmployee)
    {
        _currentEmployee = currentEmployee;
        EmployeeInput = currentEmployee;
        InitializeForm();
        BindCurrentEmployee();
        this.WireClickOutsideToBlur();
    }

    public SaveEmployeeDTO? EmployeeInput { get; private set; }

    private void InitializeForm()
    {
        var isEdit = _currentEmployee is not null;

        Text = isEdit ? "Sửa nhân viên" : "Thêm nhân viên";
        BackColor = Color.White;
        ClientSize = new Size(520, 490);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;

        // ── Header ───────────────────────────────────────────────────
        var panelHeader = new Panel
        {
            BackColor = Color.FromArgb(13, 110, 253),
            Dock = DockStyle.Top,
            Height = 72
        };
        panelHeader.Controls.Add(new Label
        {
            AutoSize = false,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            Padding = new Padding(24, 0, 0, 4),
            Text = isEdit ? "Sửa thông tin nhân viên" : "Thêm nhân viên mới",
            TextAlign = ContentAlignment.MiddleLeft
        });

        // ── Footer ───────────────────────────────────────────────────
        var panelFooter = new Panel
        {
            BackColor = Color.FromArgb(248, 249, 250),
            Dock = DockStyle.Bottom,
            Height = 64
        };
        panelFooter.Paint += (_, e) =>
        {
            using var pen = new Pen(Color.FromArgb(222, 226, 230));
            e.Graphics.DrawLine(pen, 0, 0, panelFooter.Width, 0);
        };

        var saveButton = new RoundedButton
        {
            BackColor = Color.FromArgb(13, 110, 253),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 86, 204),
            Margin = new Padding(12, 0, 0, 0),
            Size = new Size(130, 40),
            Text = isEdit ? "Lưu thay đổi" : "Thêm mới",
            UseVisualStyleBackColor = false
        };
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.Click += HandleSaveClick;

        var cancelButton = new RoundedButton
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(206, 212, 218),
            BorderRadius = 10,
            BorderSize = 1,
            DialogResult = DialogResult.Cancel,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(73, 80, 87),
            HoverBackColor = Color.FromArgb(241, 243, 245),
            Margin = new Padding(0),
            Size = new Size(110, 40),
            Text = "Hủy",
            UseVisualStyleBackColor = false
        };
        cancelButton.FlatAppearance.BorderSize = 0;

        var buttonFlow = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.RightToLeft,
            Padding = new Padding(0, 12, 24, 0),
            WrapContents = false
        };
        buttonFlow.Controls.Add(saveButton);
        buttonFlow.Controls.Add(cancelButton);
        panelFooter.Controls.Add(buttonFlow);

        // ── Body ─────────────────────────────────────────────────────
        var panelBody = new Panel
        {
            BackColor = Color.White,
            Dock = DockStyle.Fill,
            Padding = new Padding(24, 18, 24, 8)
        };

        var layout = new TableLayoutPanel
        {
            ColumnCount = 2,
            Dock = DockStyle.Fill,
            RowCount = 7
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        foreach (var rtb in new[] { _usernameTextBox, _passwordTextBox, _fullNameTextBox, _emailTextBox, _phoneTextBox })
        {
            rtb.BackColor = Color.White;
            rtb.BorderColor = Color.FromArgb(206, 212, 218);
            rtb.BorderRadius = 10;
            rtb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rtb.ForeColor = Color.FromArgb(51, 51, 51);
            rtb.Size = new Size(200, 38);
        }
        _passwordTextBox.UseSystemPasswordChar = true;

        AddRow(layout, "Tên đăng nhập", _usernameTextBox, 0);
        AddRow(layout, isEdit ? "Mật khẩu mới" : "Mật khẩu", _passwordTextBox, 1);
        AddRow(layout, "Họ và tên", _fullNameTextBox, 2);
        AddRow(layout, "Email", _emailTextBox, 3);
        AddRow(layout, "Số điện thoại", _phoneTextBox, 4);

        _roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _roleComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _roleComboBox.Items.AddRange(new object[] { "Staff", "Admin" });
        _roleComboBox.SelectedIndex = 0;
        AddRow(layout, "Vai trò", _roleComboBox, 5);

        _activeCheckBox.AutoSize = true;
        _activeCheckBox.Checked = true;
        _activeCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _activeCheckBox.ForeColor = Color.FromArgb(51, 51, 51);
        _activeCheckBox.Text = "Đang hoạt động";
        AddRow(layout, "Trạng thái", _activeCheckBox, 6, rowHeight: 42);

        panelBody.Controls.Add(layout);

        Controls.Add(panelBody);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);

        AcceptButton = saveButton;
        CancelButton = cancelButton;
    }

    private void BindCurrentEmployee()
    {
        if (_currentEmployee is null)
        {
            return;
        }

        _usernameTextBox.Text = _currentEmployee.Username;
        _fullNameTextBox.Text = _currentEmployee.FullName;
        _emailTextBox.Text = _currentEmployee.Email;
        _phoneTextBox.Text = _currentEmployee.Phone;
        _roleComboBox.SelectedItem = _currentEmployee.Role;
        _activeCheckBox.Checked = _currentEmployee.IsActive;
    }

    private void HandleSaveClick(object? sender, EventArgs e)
    {
        EmployeeInput = new SaveEmployeeDTO
        {
            Id = _currentEmployee?.Id,
            Username = _usernameTextBox.Text,
            Password = _passwordTextBox.Text,
            FullName = _fullNameTextBox.Text,
            Email = _emailTextBox.Text,
            Phone = _phoneTextBox.Text,
            Role = _roleComboBox.SelectedItem?.ToString() ?? "Staff",
            IsActive = _activeCheckBox.Checked
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    private static void AddRow(TableLayoutPanel layout, string labelText, Control control, int row, int rowHeight = 46)
    {
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, rowHeight));

        var label = new Label
        {
            AutoSize = false,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(73, 80, 87),
            Margin = new Padding(0, 14, 12, 0),
            Size = new Size(128, 18),
            Text = labelText,
            TextAlign = ContentAlignment.TopLeft
        };

        control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        control.Margin = new Padding(0, 4, 0, 0);

        layout.Controls.Add(label, 0, row);
        layout.Controls.Add(control, 1, row);
    }
}
