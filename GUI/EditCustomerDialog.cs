using PharmacyManagementSystem.BLL;

namespace PharmacyManagementSystem;

public partial class EditCustomerDialog : Form
{
    private readonly CustomerBLL _customerBLL = new();
    private readonly string _currentPhone;

    public string CustomerName { get; private set; } = string.Empty;
    public string CustomerPhone { get; private set; } = string.Empty;

    public EditCustomerDialog(string currentName, string currentPhone, string? currentAddress = null)
    {
        _currentPhone = currentPhone;
        InitializeComponent();
        _textName.Text = currentName;
        _textPhone.Text = currentPhone;
        _textAddress.Text = currentAddress ?? string.Empty;
        _buttonSave.Click += OnSave;
        _buttonCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        this.WireClickOutsideToBlur();
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
