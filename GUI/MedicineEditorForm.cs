using System.Globalization;
using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem;

public class MedicineEditorForm : Form
{
    private readonly SaveMedicineDTO? _currentMedicine;
    private readonly TextBox _codeTextBox = new();
    private readonly TextBox _nameTextBox = new();
    private readonly TextBox _unitTextBox = new();
    private readonly TextBox _manufacturerTextBox = new();
    private readonly TextBox _importPriceTextBox = new();
    private readonly TextBox _sellPriceTextBox = new();
    private readonly NumericUpDown _quantityInput = new();
    private readonly DateTimePicker _expiryDatePicker = new();
    private readonly TextBox _descriptionTextBox = new();
    private readonly CheckBox _activeCheckBox = new();

    public MedicineEditorForm(SaveMedicineDTO? currentMedicine)
    {
        _currentMedicine = currentMedicine;
        MedicineInput = currentMedicine;

        InitializeForm();
        BindCurrentMedicine();
        this.WireClickOutsideToBlur();
    }

    public SaveMedicineDTO? MedicineInput { get; private set; }

    private void InitializeForm()
    {
        Text = _currentMedicine is null ? "Thêm thuốc" : "Sửa thuốc";
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(520, 590);
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
            Padding = new Padding(0),
            RowCount = 10,
            Size = new Size(480, 485)
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        AddTextRow(layout, "Mã thuốc", _codeTextBox, 0);
        AddTextRow(layout, "Tên thuốc", _nameTextBox, 1);
        AddTextRow(layout, "Đơn vị tính", _unitTextBox, 2);
        AddTextRow(layout, "Nhà sản xuất", _manufacturerTextBox, 3);
        AddTextRow(layout, "Giá nhập", _importPriceTextBox, 4);
        AddTextRow(layout, "Giá bán", _sellPriceTextBox, 5);

        _quantityInput.Maximum = 1_000_000;
        _quantityInput.Font = Font;
        AddControlRow(layout, "Tồn kho", _quantityInput, 6);

        _expiryDatePicker.Checked = false;
        _expiryDatePicker.Format = DateTimePickerFormat.Custom;
        _expiryDatePicker.CustomFormat = "dd/MM/yyyy";
        _expiryDatePicker.ShowCheckBox = true;
        _expiryDatePicker.Font = Font;
        AddControlRow(layout, "Hạn dùng", _expiryDatePicker, 7);

        _descriptionTextBox.Multiline = true;
        _descriptionTextBox.Height = 76;
        AddControlRow(layout, "Mô tả", _descriptionTextBox, 8, 88);

        _activeCheckBox.Text = "Đang kinh doanh";
        _activeCheckBox.Checked = true;
        _activeCheckBox.AutoSize = true;
        _activeCheckBox.Font = Font;
        AddControlRow(layout, "Trạng thái", _activeCheckBox, 9);

        var saveButton = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 113, 235),
            Location = new Point(290, 525),
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
            Location = new Point(400, 525),
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

    private void BindCurrentMedicine()
    {
        if (_currentMedicine is null)
        {
            return;
        }

        _codeTextBox.Text = _currentMedicine.Code;
        _nameTextBox.Text = _currentMedicine.Name;
        _unitTextBox.Text = _currentMedicine.Unit;
        _manufacturerTextBox.Text = _currentMedicine.Manufacturer;
        _importPriceTextBox.Text = _currentMedicine.ImportPrice.ToString("0.##", CultureInfo.CurrentCulture);
        _sellPriceTextBox.Text = _currentMedicine.SellPrice.ToString("0.##", CultureInfo.CurrentCulture);
        _quantityInput.Value = Math.Max(0, Math.Min(_quantityInput.Maximum, _currentMedicine.Quantity));
        _expiryDatePicker.Checked = _currentMedicine.ExpiryDate.HasValue;

        if (_currentMedicine.ExpiryDate.HasValue)
        {
            _expiryDatePicker.Value = _currentMedicine.ExpiryDate.Value;
        }

        _descriptionTextBox.Text = _currentMedicine.Description;
        _activeCheckBox.Checked = _currentMedicine.IsActive;
    }

    private void HandleSaveClick(object? sender, EventArgs e)
    {
        if (!decimal.TryParse(_importPriceTextBox.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var importPrice))
        {
            ShowValidationMessage("Giá nhập không hợp lệ.");
            return;
        }

        if (!decimal.TryParse(_sellPriceTextBox.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out var sellPrice))
        {
            ShowValidationMessage("Giá bán không hợp lệ.");
            return;
        }

        MedicineInput = new SaveMedicineDTO
        {
            Id = _currentMedicine?.Id,
            Code = _codeTextBox.Text,
            Name = _nameTextBox.Text,
            Unit = _unitTextBox.Text,
            Manufacturer = _manufacturerTextBox.Text,
            ImportPrice = importPrice,
            SellPrice = sellPrice,
            Quantity = (int)_quantityInput.Value,
            ExpiryDate = _expiryDatePicker.Checked ? _expiryDatePicker.Value.Date : null,
            Description = _descriptionTextBox.Text,
            IsActive = _activeCheckBox.Checked
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    private void ShowValidationMessage(string message)
    {
        MessageBox.Show(this, message, "Dữ liệu chưa hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private static void AddTextRow(TableLayoutPanel layout, string labelText, TextBox textBox, int row)
    {
        textBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        textBox.Width = 330;
        AddControlRow(layout, labelText, textBox, row);
    }

    private static void AddControlRow(TableLayoutPanel layout, string labelText, Control control, int row, int height = 46)
    {
        layout.RowStyles.Add(new RowStyle(SizeType.Absolute, height));

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
