using PharmacyManagementSystem.BLL;

namespace PharmacyManagementSystem;

public class EditCustomerDialog : Form
{
    private readonly CustomerBLL _customerBLL = new();
    private readonly string _currentPhone;

    private RoundedTextBox _textName = null!;
    private RoundedTextBox _textPhone = null!;
    private RoundedTextBox _textAddress = null!;
    private RoundedButton _buttonSave = null!;
    private RoundedButton _buttonCancel = null!;

    public string CustomerName { get; private set; } = string.Empty;
    public string CustomerPhone { get; private set; } = string.Empty;

    public EditCustomerDialog(string currentName, string currentPhone, string? currentAddress = null)
    {
        _currentPhone = currentPhone;
        BuildDialog(currentName, currentPhone, currentAddress);

        _buttonSave.Click += OnSave;
        _buttonCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        this.WireClickOutsideToBlur();
    }

    private void BuildDialog(string currentName, string currentPhone, string? currentAddress)
    {
        Text = "Sửa thông tin khách hàng";
        ClientSize = new Size(460, 360);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        // Header
        var panelHeader = new Panel
        {
            BackColor = Color.FromArgb(0, 86, 179),
            Dock = DockStyle.Top,
            Height = 60
        };
        panelHeader.Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            Location = new Point(24, 14),
            Text = "Sửa thông tin khách hàng"
        });

        // Fields
        AddFieldLabel("Họ và tên *", 82);
        _textName = AddTextBox(108, currentName);

        AddFieldLabel("Số điện thoại *", 156);
        _textPhone = AddTextBox(182, currentPhone);

        AddFieldLabel("Địa chỉ (tùy chọn)", 230);
        _textAddress = AddTextBox(256, currentAddress ?? string.Empty);

        // Buttons
        _buttonCancel = new RoundedButton
        {
            BackColor = Color.FromArgb(108, 117, 125),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(88, 96, 105),
            Location = new Point(24, 308),
            Size = new Size(100, 36),
            Text = "Hủy"
        };
        _buttonCancel.FlatAppearance.BorderSize = 0;

        _buttonSave = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 105, 217),
            Location = new Point(312, 308),
            Size = new Size(124, 36),
            Text = "Lưu thay đổi"
        };
        _buttonSave.FlatAppearance.BorderSize = 0;

        Controls.Add(panelHeader);
        Controls.Add(_buttonCancel);
        Controls.Add(_buttonSave);
    }

    private void AddFieldLabel(string text, int y)
    {
        Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(24, y),
            Text = text
        });
    }

    private RoundedTextBox AddTextBox(int y, string text)
    {
        var tb = new RoundedTextBox
        {
            BorderColor = Color.FromArgb(170, 183, 196),
            BorderRadius = 8,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(24, y),
            Size = new Size(412, 34),
            Text = text
        };
        Controls.Add(tb);
        return tb;
    }

    private void OnSave(object? sender, EventArgs e)
    {
        var name = _textName.Text.Trim();
        var phone = _textPhone.Text.Trim();
        var address = _textAddress.Text.Trim();

        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(this, "Vui lòng nhập họ và tên khách hàng.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _textName.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(phone))
        {
            MessageBox.Show(this, "Vui lòng nhập số điện thoại.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _textPhone.Focus();
            return;
        }

        try
        {
            _customerBLL.UpdateCustomer(_currentPhone, name, phone, string.IsNullOrWhiteSpace(address) ? null : address);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Lỗi cập nhật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        CustomerName = name;
        CustomerPhone = phone;
        DialogResult = DialogResult.OK;
        Close();
    }
}
