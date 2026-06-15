using System.Globalization;
using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem;

public class MedicineEditorForm : Form
{
    private readonly SaveMedicineDTO? _currentMedicine;
    private readonly RoundedTextBox _codeTextBox = new();
    private readonly RoundedTextBox _nameTextBox = new();
    private readonly RoundedTextBox _unitTextBox = new();
    private readonly RoundedTextBox _manufacturerTextBox = new();
    private readonly RoundedTextBox _importPriceTextBox = new();
    private readonly RoundedTextBox _sellPriceTextBox = new();
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
        var isEdit = _currentMedicine is not null;

        Text = isEdit ? "Sửa thuốc" : "Thêm thuốc";
        BackColor = Color.White;
        ClientSize = new Size(520, 650);
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
            Text = isEdit ? "Sửa thông tin thuốc" : "Thêm thuốc mới",
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
            RowCount = 10
        };
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 128F));
        layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

        foreach (var rtb in new[] { _codeTextBox, _nameTextBox, _unitTextBox, _manufacturerTextBox, _importPriceTextBox, _sellPriceTextBox })
        {
            rtb.BackColor = Color.White;
            rtb.BorderColor = Color.FromArgb(206, 212, 218);
            rtb.BorderRadius = 10;
            rtb.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rtb.ForeColor = Color.FromArgb(51, 51, 51);
            rtb.Size = new Size(200, 38);
        }

        AddRow(layout, "Mã thuốc", _codeTextBox, 0);
        AddRow(layout, "Tên thuốc", _nameTextBox, 1);
        AddRow(layout, "Đơn vị tính", _unitTextBox, 2);
        AddRow(layout, "Nhà sản xuất", _manufacturerTextBox, 3);
        AddRow(layout, "Giá nhập (đ)", _importPriceTextBox, 4);
        AddRow(layout, "Giá bán (đ)", _sellPriceTextBox, 5);

        _quantityInput.Maximum = 1_000_000;
        _quantityInput.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        AddRow(layout, "Tồn kho", _quantityInput, 6);

        _expiryDatePicker.Checked = false;
        _expiryDatePicker.Format = DateTimePickerFormat.Custom;
        _expiryDatePicker.CustomFormat = "dd/MM/yyyy";
        _expiryDatePicker.ShowCheckBox = true;
        _expiryDatePicker.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        AddRow(layout, "Hạn dùng", _expiryDatePicker, 7);

        _descriptionTextBox.BackColor = Color.FromArgb(253, 253, 253);
        _descriptionTextBox.BorderStyle = BorderStyle.FixedSingle;
        _descriptionTextBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _descriptionTextBox.ForeColor = Color.FromArgb(51, 51, 51);
        _descriptionTextBox.Multiline = true;
        _descriptionTextBox.Size = new Size(200, 78);
        AddRow(layout, "Mô tả", _descriptionTextBox, 8, rowHeight: 90);

        _activeCheckBox.AutoSize = true;
        _activeCheckBox.Checked = true;
        _activeCheckBox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _activeCheckBox.ForeColor = Color.FromArgb(51, 51, 51);
        _activeCheckBox.Text = "Đang kinh doanh";
        AddRow(layout, "Trạng thái", _activeCheckBox, 9, rowHeight: 42);

        panelBody.Controls.Add(layout);

        Controls.Add(panelBody);
        Controls.Add(panelFooter);
        Controls.Add(panelHeader);

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
