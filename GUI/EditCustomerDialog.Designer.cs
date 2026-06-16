namespace PharmacyManagementSystem;

partial class EditCustomerDialog
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        panelHeader = new Panel();
        labelTitle = new Label();
        labelName = new Label();
        _textName = new RoundedTextBox();
        labelPhone = new Label();
        _textPhone = new RoundedTextBox();
        labelAddress = new Label();
        _textAddress = new RoundedTextBox();
        _buttonCancel = new RoundedButton();
        _buttonSave = new RoundedButton();
        panelHeader.SuspendLayout();
        SuspendLayout();
        //
        // panelHeader
        //
        panelHeader.BackColor = Color.FromArgb(0, 86, 179);
        panelHeader.Controls.Add(labelTitle);
        panelHeader.Dock = DockStyle.Top;
        panelHeader.Height = 60;
        //
        // labelTitle
        //
        labelTitle.AutoSize = true;
        labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point);
        labelTitle.ForeColor = Color.White;
        labelTitle.Location = new Point(24, 14);
        labelTitle.Text = "Sửa thông tin khách hàng";
        //
        // labelName
        //
        labelName.AutoSize = true;
        labelName.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelName.ForeColor = Color.FromArgb(51, 51, 51);
        labelName.Location = new Point(24, 82);
        labelName.Text = "Họ và tên *";
        //
        // _textName
        //
        _textName.BorderColor = Color.FromArgb(170, 183, 196);
        _textName.BorderRadius = 8;
        _textName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _textName.Location = new Point(24, 108);
        _textName.Size = new Size(412, 34);
        //
        // labelPhone
        //
        labelPhone.AutoSize = true;
        labelPhone.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelPhone.ForeColor = Color.FromArgb(51, 51, 51);
        labelPhone.Location = new Point(24, 156);
        labelPhone.Text = "Số điện thoại *";
        //
        // _textPhone
        //
        _textPhone.BorderColor = Color.FromArgb(170, 183, 196);
        _textPhone.BorderRadius = 8;
        _textPhone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _textPhone.Location = new Point(24, 182);
        _textPhone.Size = new Size(412, 34);
        //
        // labelAddress
        //
        labelAddress.AutoSize = true;
        labelAddress.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        labelAddress.ForeColor = Color.FromArgb(51, 51, 51);
        labelAddress.Location = new Point(24, 230);
        labelAddress.Text = "Địa chỉ (tùy chọn)";
        //
        // _textAddress
        //
        _textAddress.BorderColor = Color.FromArgb(170, 183, 196);
        _textAddress.BorderRadius = 8;
        _textAddress.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        _textAddress.Location = new Point(24, 256);
        _textAddress.Size = new Size(412, 34);
        //
        // _buttonCancel
        //
        _buttonCancel.BackColor = Color.FromArgb(108, 117, 125);
        _buttonCancel.BorderRadius = 10;
        _buttonCancel.BorderSize = 0;
        _buttonCancel.FlatStyle = FlatStyle.Flat;
        _buttonCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _buttonCancel.ForeColor = Color.White;
        _buttonCancel.HoverBackColor = Color.FromArgb(88, 96, 105);
        _buttonCancel.Location = new Point(24, 308);
        _buttonCancel.Size = new Size(100, 36);
        _buttonCancel.Text = "Hủy";
        _buttonCancel.FlatAppearance.BorderSize = 0;
        //
        // _buttonSave
        //
        _buttonSave.BackColor = Color.FromArgb(0, 123, 255);
        _buttonSave.BorderRadius = 10;
        _buttonSave.BorderSize = 0;
        _buttonSave.FlatStyle = FlatStyle.Flat;
        _buttonSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
        _buttonSave.ForeColor = Color.White;
        _buttonSave.HoverBackColor = Color.FromArgb(0, 105, 217);
        _buttonSave.Location = new Point(312, 308);
        _buttonSave.Size = new Size(124, 36);
        _buttonSave.Text = "Lưu thay đổi";
        _buttonSave.FlatAppearance.BorderSize = 0;
        //
        // EditCustomerDialog
        //
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(460, 360);
        Controls.Add(labelName);
        Controls.Add(_textName);
        Controls.Add(labelPhone);
        Controls.Add(_textPhone);
        Controls.Add(labelAddress);
        Controls.Add(_textAddress);
        Controls.Add(_buttonCancel);
        Controls.Add(_buttonSave);
        Controls.Add(panelHeader);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Sửa thông tin khách hàng";
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private Panel panelHeader = null!;
    private Label labelTitle = null!;
    private Label labelName = null!;
    private RoundedTextBox _textName = null!;
    private Label labelPhone = null!;
    private RoundedTextBox _textPhone = null!;
    private Label labelAddress = null!;
    private RoundedTextBox _textAddress = null!;
    private RoundedButton _buttonCancel = null!;
    private RoundedButton _buttonSave = null!;
}
