using PharmacyManagementSystem.BLL;

namespace PharmacyManagementSystem;

public partial class CreateCustomerDialog : Form
{
    private readonly CustomerBLL _customerBLL = new();

    public string CustomerName { get; private set; } = string.Empty;
    public string CustomerPhone { get; private set; } = string.Empty;

    public CreateCustomerDialog(string prefilledPhone)
    {
        InitializeComponent();
        _textPhone.Text = prefilledPhone;
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
            _customerBLL.CreateCustomer(name, phone, string.IsNullOrWhiteSpace(address) ? null : address);
        }
        catch
        {
            // Bỏ qua lỗi trùng SĐT — tên vẫn được dùng cho hóa đơn
        }

        CustomerName = name;
        CustomerPhone = phone;
        DialogResult = DialogResult.OK;
        Close();
    }
}
