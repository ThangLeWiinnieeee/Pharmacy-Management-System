using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem;

public class EmployeeEditorForm : Form
{
    private readonly SaveEmployeeDTO? _currentEmployee;
    private readonly TextBox _usernameTextBox = new();
    private readonly TextBox _passwordTextBox = new();
    private readonly TextBox _fullNameTextBox = new();
    private readonly TextBox _emailTextBox = new();
    private readonly TextBox _phoneTextBox = new();
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
        Text = _currentEmployee is null ? "Thêm nhân viên" : "Sửa nhân viên";
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(520, 430);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;

        var layout = new TableLayoutPanel
        {
            ColumnCount = 2,
            Dock = DockStyle.Top,
            Location = new Point(20, 20),
            RowCount = 7,
            Size = new Size(480, 320)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        AddTextRow(layout, "Tên đăng nhập", _usernameTextBox, 0);
        AddTextRow(layout, _currentEmployee is null ? "Mật khẩu" : "Mật khẩu mới", _passwordTextBox, 1);
        _passwordTextBox.UseSystemPasswordChar = true;
        AddTextRow(layout, "Họ tên", _fullNameTextBox, 2);
        AddTextRow(layout, "Email", _emailTextBox, 3);
        AddTextRow(layout, "Số điện thoại", _phoneTextBox, 4);

        _roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        _roleComboBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _roleComboBox.Items.AddRange(new object[] { "Staff", "Admin" });
        _roleComboBox.SelectedIndex = 0;
        AddControlRow(layout, "Vai trò", _roleComboBox, 5);

        _activeCheckBox.Text = "Đang hoạt động";
        _activeCheckBox.Checked = true;
        _activeCheckBox.AutoSize = true;
        _activeCheckBox.Font = Font;
        AddControlRow(layout, "Trạng thái", _activeCheckBox, 6);

        var saveButton = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 113, 235),
            Location = new Point(290, 365),
            Size = new Size(96, 38),
            Text = "Lưu",
            UseVisualStyleBackColor = false
        };
        saveButton.FlatAppearance.BorderSize = 0;
        saveButton.Click += HandleSaveClick;

        var cancelButton = new RoundedButton
        {
            BackColor = Color.FromArgb(108, 117, 125),
            BorderRadius = 12,
            BorderSize = 0,
            DialogResult = DialogResult.Cancel,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(98, 106, 113),
            Location = new Point(400, 365),
            Size = new Size(96, 38),
            Text = "Hủy",
            UseVisualStyleBackColor = false
        };
        cancelButton.FlatAppearance.BorderSize = 0;

        Controls.Add(layout);
        Controls.Add(saveButton);
        Controls.Add(cancelButton);
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

    private static void AddTextRow(TableLayoutPanel layout, string labelText, TextBox textBox, int row)
    {
        textBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        textBox.Width = 330;
        AddControlRow(layout, labelText, textBox, row);
    }

    private static void AddControlRow(TableLayoutPanel layout, string labelText, Control control, int row)
    {
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));

        var label = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Margin = new Padding(0, 8, 12, 0),
            Text = labelText
        };

        control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
        control.Margin = new Padding(0, 4, 0, 0);

        layout.Controls.Add(label, 0, row);
        layout.Controls.Add(control, 1, row);
    }
}
