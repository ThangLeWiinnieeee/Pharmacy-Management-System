using System.Globalization;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

/// <summary>
/// Form lập hóa đơn bán thuốc dành cho nhân viên.
/// Implement IInvoiceEditorView theo đúng MVP pattern.
/// </summary>
public class InvoiceEditorForm : Form, IInvoiceEditorView
{
    private readonly InvoicePresenter _presenter;
    private readonly List<InvoiceDetailInputDTO> _cartItems = [];

    // Header controls
    private Label _labelInvoiceCode = null!;

    // Customer info
    private RoundedTextBox _textCustomerName = null!;
    private RoundedTextBox _textCustomerPhone = null!;

    // Cart grid
    private DataGridView _cartGrid = null!;

    // Totals
    private Label _labelTotal = null!;
    private Label _labelDiscount = null!;
    private Label _labelFinal = null!;
    private NumericUpDown _numDiscount = null!;

    // Note
    private RoundedTextBox _textNote = null!;

    // Buttons
    private RoundedButton _buttonAddMedicine = null!;
    private RoundedButton _buttonRemoveItem = null!;
    private RoundedButton _buttonSave = null!;
    private RoundedButton _buttonCancel = null!;

    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    public InvoiceEditorForm(UserDTO currentUser)
    {
        InitializeLayout(currentUser.FullName);
        _presenter = new InvoicePresenter(this, currentUser.Id);

        // Bind events
        _buttonAddMedicine.Click += (_, _) => _presenter.AddMedicineToCart();
        _buttonRemoveItem.Click += (_, _) => RemoveSelectedCartItem();
        _numDiscount.ValueChanged += (_, _) => _presenter.RefreshTotals();
        _numDiscount.Leave += (_, _) =>
        {
            // Khi người dùng xóa hết rồi click ra ngoài, parse thủ công để tránh lỗi
            var text = _numDiscount.Text.Replace(",", "").Replace(".", "").Trim();
            if (!decimal.TryParse(text, out var parsed) || parsed < 0)
            {
                _numDiscount.Value = 0;
                _presenter.RefreshTotals();
            }
        };
        _buttonSave.Click += (_, _) => _presenter.SaveInvoice();
        _buttonCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };

        _presenter.RefreshTotals();
    }

    // ─── IInvoiceEditorView ────────────────────────────────────────────────

    public string CustomerName => _textCustomerName.Text.Trim();
    public string CustomerPhone => _textCustomerPhone.Text.Trim();
    public decimal Discount => _numDiscount.Value;
    public string Note => _textNote.Text.Trim();
    public IReadOnlyList<InvoiceDetailInputDTO> CartItems => _cartItems.AsReadOnly();

    public void ShowMessage(string message) =>
        MessageBox.Show(this, message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

    public void ShowError(string message) =>
        MessageBox.Show(this, message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

    public bool Confirm(string message) =>
        MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    public void ResetForm(string newInvoiceCode)
    {
        _labelInvoiceCode.Text = $"Mã hóa đơn: {newInvoiceCode}";
        _textCustomerName.Text = string.Empty;
        _textCustomerPhone.Text = string.Empty;
        _numDiscount.Value = 0;
        _textNote.Text = string.Empty;
        _cartItems.Clear();
        RefreshCartGrid(); // vẽ lại grid + reset tổng tiền về 0
    }

    public void RefreshTotals(decimal total, decimal discount, decimal finalAmount)
    {
        _labelTotal.Text = $"Tổng tiền hàng: {total:N0} đ";
        _labelDiscount.Text = $"Giảm giá: {discount:N0} đ";
        _labelFinal.Text = $"{finalAmount:N0} đ";
    }

    public IReadOnlyList<InvoiceDetailInputDTO>? RequestSelectMedicines()
    {
        var medicines = _presenter.GetAvailableMedicines();
        using var picker = new MedicinePickerDialog(medicines);

        if (picker.ShowDialog(this) != DialogResult.OK || picker.SelectedItems.Count == 0)
        {
            return null;
        }

        // Merge tất cả items từ dialog (multi-select) vào giỏ hàng của form
        foreach (var newItem in picker.SelectedItems)
        {
            var existing = _cartItems.FirstOrDefault(d => d.MedicineId == newItem.MedicineId);
            if (existing is not null)
            {
                // Cộng dồn số lượng nếu đã có
                existing.Quantity += newItem.Quantity;
            }
            else
            {
                _cartItems.Add(newItem);
            }
        }

        RefreshCartGrid();
        return picker.SelectedItems;
    }

    // ─── Private helpers ───────────────────────────────────────────────────

    private void RemoveSelectedCartItem()
    {
        if (_cartGrid.CurrentRow?.Tag is not InvoiceDetailInputDTO item) return;
        _cartItems.Remove(item);
        RefreshCartGrid();
    }

    /// <summary>
    /// Vẽ lại toàn bộ giỏ hàng từ _cartItems và cập nhật tổng tiền.
    /// Đây là nguồn sự thật duy nhất để hiển thị danh sách hóa đơn.
    /// </summary>
    private void RefreshCartGrid()
    {
        _cartGrid.Rows.Clear();

        foreach (var item in _cartItems)
        {
            var idx = _cartGrid.Rows.Add(
                item.MedicineCode,
                item.MedicineName,
                item.Unit,
                item.Quantity.ToString("N0", Vi),
                item.UnitPrice.ToString("N0", Vi),
                item.LineTotal.ToString("N0", Vi));
            _cartGrid.Rows[idx].Tag = item;
        }

        // Một lần duy nhất tính và hiển thị tổng tiền
        _presenter.RefreshTotals();
    }

    // ─── Layout ────────────────────────────────────────────────────────────

    private void InitializeLayout(string staffName)
    {
        Text = "Lập hóa đơn";
        ClientSize = new Size(1020, 680);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        // ── Header ──────────────────────────────────────────────────────────
        var panelHeader = new Panel
        {
            BackColor = Color.FromArgb(0, 86, 179),
            Dock = DockStyle.Top,
            Height = 72,
            Padding = new Padding(28, 0, 28, 0)
        };

        var labelTitle = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 17F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            Location = new Point(28, 14),
            Text = "Lập hóa đơn bán thuốc"
        };

        var newCode = "HD" + DateTime.Now.ToString("yyMMddHHmmss");
        _labelInvoiceCode = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(180, 215, 255),
            Location = new Point(31, 48),
            Text = $"Mã hóa đơn: {newCode}"
        };

        var labelStaff = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(180, 215, 255),
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(750, 32),
            Text = $"Nhân viên: {staffName}"
        };

        _buttonCancel = new RoundedButton
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            BackColor = Color.FromArgb(248, 249, 250),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(0, 86, 179),
            HoverBackColor = Color.FromArgb(224, 239, 255),
            Location = new Point(900, 20),
            Size = new Size(90, 34),
            Text = "Đóng"
        };
        _buttonCancel.FlatAppearance.BorderSize = 0;

        panelHeader.Controls.AddRange([labelTitle, _labelInvoiceCode, labelStaff, _buttonCancel]);

        // ── Content area ─────────────────────────────────────────────────────
        var panelContent = new Panel
        {
            BackColor = Color.FromArgb(248, 249, 250),
            Dock = DockStyle.Fill,
            Padding = new Padding(24, 20, 24, 20)
        };

        // ── Customer info card ───────────────────────────────────────────────
        var cardCustomer = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(24, 20),
            Size = new Size(480, 110),
            Padding = new Padding(20, 14, 20, 14)
        };

        var labelCustTitle = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(20, 14),
            Text = "Thông tin khách hàng (tùy chọn)"
        };

        var labelCustName = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(20, 48),
            Text = "Tên:"
        };

        _textCustomerName = new RoundedTextBox
        {
            BorderColor = Color.FromArgb(170, 183, 196),
            BorderRadius = 8,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(52, 44),
            Size = new Size(170, 32)
        };

        var labelCustPhone = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(236, 48),
            Text = "SĐT:"
        };

        _textCustomerPhone = new RoundedTextBox
        {
            BorderColor = Color.FromArgb(170, 183, 196),
            BorderRadius = 8,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(268, 44),
            Size = new Size(170, 32)
        };

        cardCustomer.Controls.AddRange([labelCustTitle, labelCustName, _textCustomerName, labelCustPhone, _textCustomerPhone]);

        // ── Note card ───────────────────────────────────────────────────────
        var cardNote = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(516, 20),
            Size = new Size(480, 110),
            Padding = new Padding(20, 14, 20, 14)
        };

        var labelNoteTitle = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(20, 14),
            Text = "Ghi chú"
        };

        _textNote = new RoundedTextBox
        {
            BorderColor = Color.FromArgb(170, 183, 196),
            BorderRadius = 8,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(20, 44),
            Size = new Size(440, 32)
        };

        cardNote.Controls.AddRange([labelNoteTitle, _textNote]);

        // ── Cart section ─────────────────────────────────────────────────────
        var cardCart = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(24, 148),
            Size = new Size(972, 340),
            Padding = new Padding(16)
        };

        var labelCartTitle = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(20, 16),
            Text = "Danh sách thuốc bán"
        };

        _buttonAddMedicine = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 113, 235),
            Location = new Point(750, 10),
            Size = new Size(120, 34),
            Text = "+ Thêm thuốc"
        };
        _buttonAddMedicine.FlatAppearance.BorderSize = 0;

        _buttonRemoveItem = new RoundedButton
        {
            BackColor = Color.FromArgb(220, 53, 69),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(200, 43, 58),
            Location = new Point(880, 10),
            Size = new Size(80, 34),
            Text = "Xóa dòng"
        };
        _buttonRemoveItem.FlatAppearance.BorderSize = 0;

        _cartGrid = new DataGridView
        {
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            ColumnHeadersHeight = 38,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            EnableHeadersVisualStyles = false,
            GridColor = Color.FromArgb(233, 236, 239),
            Location = new Point(16, 54),
            MultiSelect = false,
            ReadOnly = true,
            RowHeadersVisible = false,
            RowTemplate = { Height = 36 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            Size = new Size(940, 266)
        };

        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã thuốc", Name = "colCode", FillWeight = 12, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc", Name = "colName", FillWeight = 38, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn vị", Name = "colUnit", FillWeight = 10, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số lượng", Name = "colQty", FillWeight = 10, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá (đ)", Name = "colPrice", FillWeight = 15, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền (đ)", Name = "colTotal", FillWeight = 15, ReadOnly = true });

        StyleCartGrid();

        cardCart.Controls.AddRange([labelCartTitle, _buttonAddMedicine, _buttonRemoveItem, _cartGrid]);

        // ── Totals & submit ──────────────────────────────────────────────────
        var cardTotals = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(24, 506),
            Size = new Size(972, 90),
            Padding = new Padding(24, 16, 24, 16)
        };

        _labelTotal = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(24, 18),
            Text = "Tổng tiền hàng: 0 đ"
        };

        var labelDiscountLbl = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(260, 18),
            Text = "Giảm giá (đ):"
        };

        _numDiscount = new NumericUpDown
        {
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(364, 14),
            Maximum = 999_999_999,
            Minimum = 0,
            Size = new Size(120, 30),
            ThousandsSeparator = true,
            Value = 0
        };

        _labelDiscount = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(220, 53, 69),
            Location = new Point(496, 18),
            Text = "Giảm giá: 0 đ"
        };

        var labelFinalLbl = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(650, 16),
            Text = "THANH TOÁN:"
        };

        _labelFinal = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(0, 123, 255),
            Location = new Point(762, 10),
            Text = "0 đ"
        };

        _buttonSave = new RoundedButton
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            BackColor = Color.FromArgb(40, 167, 69),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(33, 150, 60),
            Location = new Point(868, 14),
            Size = new Size(120, 44),
            Text = "Lưu hóa đơn"
        };
        _buttonSave.FlatAppearance.BorderSize = 0;

        cardTotals.Controls.AddRange([_labelTotal, labelDiscountLbl, _numDiscount, _labelDiscount, labelFinalLbl, _labelFinal, _buttonSave]);

        panelContent.Controls.AddRange([cardCustomer, cardNote, cardCart, cardTotals]);

        Controls.Add(panelContent);
        Controls.Add(panelHeader);
    }

    private void StyleCartGrid()
    {
        var headerStyle = _cartGrid.ColumnHeadersDefaultCellStyle;
        headerStyle.BackColor = Color.FromArgb(240, 244, 248);
        headerStyle.ForeColor = Color.FromArgb(51, 51, 51);
        headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        headerStyle.SelectionBackColor = headerStyle.BackColor;
        headerStyle.SelectionForeColor = headerStyle.ForeColor;

        _cartGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 236, 255);
        _cartGrid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 86, 179);
        _cartGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
    }

}
