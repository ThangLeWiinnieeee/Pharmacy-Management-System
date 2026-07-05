namespace PharmacyManagementSystem;

partial class EditBatchDialog
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelHeader = new Panel();
        labelHeaderTitle = new Label();
        labelMedicineName = new Label();
        labelImportDate = new Label();
        _pickerImportDate = new DateTimePicker();
        labelQty = new Label();
        _numQty = new NumericUpDown();
        labelExpiry = new Label();
        _pickerExpiry = new DateTimePicker();
        labelImportPrice = new Label();
        _textImportPrice = new RoundedTextBox();
        labelNote = new Label();
        _textNote = new RoundedTextBox();
        _btnCancel = new RoundedButton();
        _btnSave = new RoundedButton();
        panelHeader.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_numQty).BeginInit();
        SuspendLayout();
        //
        // panelHeader
        //
        panelHeader.BackColor = Color.FromArgb(0, 86, 179);
        panelHeader.Controls.Add(labelMedicineName);
        panelHeader.Controls.Add(labelHeaderTitle);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Height = 60;
        //
        // labelHeaderTitle
        //
        labelHeaderTitle.AutoSize = true;
        labelHeaderTitle.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
        labelHeaderTitle.ForeColor = Color.White;
        labelHeaderTitle.Location = new Point(24, 10);
        labelHeaderTitle.Text = "Sửa thông tin lô hàng";
        //
        // labelMedicineName
        //
        labelMedicineName.AutoSize = true;
        labelMedicineName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        labelMedicineName.ForeColor = Color.FromArgb(180, 215, 255);
        labelMedicineName.Location = new Point(26, 38);
        labelMedicineName.Text = "";
        //
        // labelImportDate
        //
        labelImportDate.AutoSize = true;
        labelImportDate.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelImportDate.ForeColor = Color.FromArgb(51, 51, 51);
        labelImportDate.Location = new Point(24, 82);
        labelImportDate.Text = "Ngày nhập *";
        //
        // _pickerImportDate
        //
        _pickerImportDate.CustomFormat = "dd/MM/yyyy";
        _pickerImportDate.Format = DateTimePickerFormat.Custom;
        _pickerImportDate.Location = new Point(24, 104);
        _pickerImportDate.Size = new Size(200, 28);
        _pickerImportDate.Value = DateTime.Today;
        //
        // labelQty
        //
        labelQty.AutoSize = true;
        labelQty.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelQty.ForeColor = Color.FromArgb(51, 51, 51);
        labelQty.Location = new Point(24, 144);
        labelQty.Text = "Số lượng nhập *";
        //
        // _numQty
        //
        _numQty.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _numQty.Location = new Point(24, 166);
        _numQty.Maximum = 1_000_000;
        _numQty.Minimum = 1;
        _numQty.Size = new Size(140, 28);
        _numQty.Value = 1;
        //
        // labelExpiry
        //
        labelExpiry.AutoSize = true;
        labelExpiry.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelExpiry.ForeColor = Color.FromArgb(51, 51, 51);
        labelExpiry.Location = new Point(24, 206);
        labelExpiry.Text = "Hạn dùng *";
        //
        // _pickerExpiry
        //
        _pickerExpiry.CustomFormat = "dd/MM/yyyy";
        _pickerExpiry.Format = DateTimePickerFormat.Custom;
        _pickerExpiry.Location = new Point(24, 228);
        _pickerExpiry.Size = new Size(200, 28);
        _pickerExpiry.Value = DateTime.Today.AddYears(2);
        //
        // labelImportPrice
        //
        labelImportPrice.AutoSize = true;
        labelImportPrice.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelImportPrice.ForeColor = Color.FromArgb(51, 51, 51);
        labelImportPrice.Location = new Point(24, 268);
        labelImportPrice.Text = "Giá nhập *";
        //
        // _textImportPrice
        //
        _textImportPrice.BorderColor = Color.FromArgb(170, 183, 196);
        _textImportPrice.BorderRadius = 8;
        _textImportPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _textImportPrice.Location = new Point(24, 290);
        _textImportPrice.Size = new Size(412, 34);
        //
        // labelNote
        //
        labelNote.AutoSize = true;
        labelNote.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelNote.ForeColor = Color.FromArgb(51, 51, 51);
        labelNote.Location = new Point(24, 330);
        labelNote.Text = "Ghi chú (tùy chọn)";
        //
        // _textNote
        //
        _textNote.BorderColor = Color.FromArgb(170, 183, 196);
        _textNote.BorderRadius = 8;
        _textNote.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _textNote.Location = new Point(24, 352);
        _textNote.Size = new Size(412, 34);
        //
        // _btnCancel
        //
        _btnCancel.BackColor = Color.FromArgb(108, 117, 125);
        _btnCancel.BorderRadius = 10;
        _btnCancel.BorderSize = 0;
        _btnCancel.FlatStyle = FlatStyle.Flat;
        _btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _btnCancel.ForeColor = Color.White;
        _btnCancel.HoverBackColor = Color.FromArgb(88, 96, 105);
        _btnCancel.Location = new Point(24, 406);
        _btnCancel.Size = new Size(100, 36);
        _btnCancel.Text = "Hủy";
        _btnCancel.FlatAppearance.BorderSize = 0;
        //
        // _btnSave
        //
        _btnSave.BackColor = Color.FromArgb(0, 123, 180);
        _btnSave.BorderRadius = 10;
        _btnSave.BorderSize = 0;
        _btnSave.FlatStyle = FlatStyle.Flat;
        _btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _btnSave.ForeColor = Color.White;
        _btnSave.HoverBackColor = Color.FromArgb(0, 100, 155);
        _btnSave.Location = new Point(288, 406);
        _btnSave.Size = new Size(148, 36);
        _btnSave.Text = "Lưu thay đổi";
        _btnSave.FlatAppearance.BorderSize = 0;
        //
        // EditBatchDialog
        //
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(460, 460);
        Controls.Add(labelImportDate);
        Controls.Add(_pickerImportDate);
        Controls.Add(labelQty);
        Controls.Add(_numQty);
        Controls.Add(labelExpiry);
        Controls.Add(_pickerExpiry);
        Controls.Add(labelImportPrice);
        Controls.Add(_textImportPrice);
        Controls.Add(labelNote);
        Controls.Add(_textNote);
        Controls.Add(_btnCancel);
        Controls.Add(_btnSave);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sửa lô hàng";
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_numQty).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel panelHeader = null!;
    private Label labelHeaderTitle = null!;
    private Label labelMedicineName = null!;
    private Label labelImportDate = null!;
    private DateTimePicker _pickerImportDate = null!;
    private Label labelQty = null!;
    private NumericUpDown _numQty = null!;
    private Label labelExpiry = null!;
    private DateTimePicker _pickerExpiry = null!;
    private Label labelImportPrice = null!;
    private RoundedTextBox _textImportPrice = null!;
    private Label labelNote = null!;
    private RoundedTextBox _textNote = null!;
    private RoundedButton _btnCancel = null!;
    private RoundedButton _btnSave = null!;
}
