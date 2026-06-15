using System.Globalization;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

public class EditBatchDialog : Form
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");
    private readonly MedicineBatchDAL _dal = new();
    private readonly MedicineBatchDTO _batch;
    private readonly MedicineDTO _medicine;

    private DateTimePicker _pickerImportDate = null!;
    private NumericUpDown  _numQty           = null!;
    private DateTimePicker _pickerExpiry     = null!;
    private RoundedTextBox _textImportPrice  = null!;
    private RoundedTextBox _textNote         = null!;
    private RoundedButton  _btnSave          = null!;
    private RoundedButton  _btnCancel        = null!;

    public EditBatchDialog(MedicineBatchDTO batch, MedicineDTO medicine)
    {
        _batch    = batch;
        _medicine = medicine;
        BuildDialog();
        _btnSave.Click   += OnSave;
        _btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        this.WireClickOutsideToBlur();
    }

    private void BuildDialog()
    {
        Text = "Sửa lô hàng";
        ClientSize = new Size(460, 460);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        var header = new Panel { BackColor = Color.FromArgb(0, 86, 179), Dock = DockStyle.Top, Height = 60 };
        header.Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            Location = new Point(24, 10),
            Text = "Sửa thông tin lô hàng"
        });
        header.Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(180, 215, 255),
            Location = new Point(26, 38),
            Text = _medicine.Name
        });

        AddFieldLabel("Ngày nhập *", 82);
        _pickerImportDate = new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd/MM/yyyy",
            Location = new Point(24, 104),
            Size = new Size(200, 28),
            Value = _batch.ImportDate
        };
        Controls.Add(_pickerImportDate);

        AddFieldLabel("Số lượng nhập *", 144);
        _numQty = new NumericUpDown
        {
            Location = new Point(24, 166),
            Size = new Size(140, 28),
            Minimum = 1,
            Maximum = 1_000_000,
            Value = _batch.ImportQuantity,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point)
        };
        Controls.Add(_numQty);

        AddFieldLabel("Hạn dùng *", 206);
        _pickerExpiry = new DateTimePicker
        {
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd/MM/yyyy",
            Location = new Point(24, 228),
            Size = new Size(200, 28),
            Value = _batch.ExpiryDate ?? DateTime.Today.AddYears(2)
        };
        Controls.Add(_pickerExpiry);

        AddFieldLabel("Giá nhập *", 268);
        _textImportPrice = AddTextBox(290, _batch.ImportPrice.ToString("N0", Vi));

        AddFieldLabel("Ghi chú (tùy chọn)", 330);
        _textNote = AddTextBox(352, _batch.Note ?? string.Empty);

        _btnCancel = new RoundedButton
        {
            BackColor = Color.FromArgb(108, 117, 125),
            BorderRadius = 10, BorderSize = 0, FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White, HoverBackColor = Color.FromArgb(88, 96, 105),
            Location = new Point(24, 406), Size = new Size(100, 36), Text = "Hủy"
        };
        _btnCancel.FlatAppearance.BorderSize = 0;

        _btnSave = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 10, BorderSize = 0, FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White, HoverBackColor = Color.FromArgb(0, 105, 217),
            Location = new Point(288, 406), Size = new Size(148, 36), Text = "Lưu thay đổi"
        };
        _btnSave.FlatAppearance.BorderSize = 0;

        Controls.AddRange([header, _btnCancel, _btnSave]);
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
            _dal.Update(
                _batch.Id,
                importDate,
                (int)_numQty.Value,
                expiryDate,
                importPrice,
                _textNote.Text.Trim());
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message, "Lỗi sửa lô", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
