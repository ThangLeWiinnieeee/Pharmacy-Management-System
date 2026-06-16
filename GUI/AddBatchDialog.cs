using System.Globalization;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

public partial class AddBatchDialog : Form
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");
    private readonly MedicineBatchDAL _dal = new();
    private readonly MedicineDTO _medicine;

    public AddBatchDialog(MedicineDTO medicine)
    {
        _medicine = medicine;
        InitializeComponent();
        labelMedicineName.Text = medicine.Name;
        _textImportPrice.Text = medicine.ImportPrice.ToString("N0", Vi);
        _btnSave.Click += OnSave;
        _btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        this.WireClickOutsideToBlur();
    }

    private void OnSave(object? sender, EventArgs e)
    {
        var importDate = _pickerImportDate.Value.Date;
        var expiryDate = _pickerExpiry.Value.Date;

        if (expiryDate <= importDate)
        {
            MessageBox.Show(this, "Hạn dùng phải sau ngày nhập lô.",
                "Kiểm tra dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            _pickerExpiry.Focus();
            return;
        }

        var rawPrice = _textImportPrice.Text.Replace(",", "").Replace(".", "").Trim();
        if (!decimal.TryParse(_textImportPrice.Text.Trim(), NumberStyles.Number, Vi, out var importPrice))
        {
            if (!decimal.TryParse(rawPrice, out importPrice) || importPrice < 0)
            {
                MessageBox.Show(this, "Giá nhập không hợp lệ.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _textImportPrice.Focus();
                return;
            }
        }

        try
        {
            _dal.Add(
                _medicine.Id,
                importDate,
                (int)_numQty.Value,
                expiryDate,
                importPrice,
                _textNote.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Lỗi nhập lô", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
