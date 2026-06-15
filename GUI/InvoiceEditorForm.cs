using System.Globalization;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public class InvoiceEditorForm : Form, IInvoiceEditorView
{
    private readonly InvoicePresenter _presenter;
    private readonly List<InvoiceDetailInputDTO> _cartItems = [];

    // Header
    private Label _labelInvoiceCode = null!;

    // Customer lookup state
    private enum CustomerState { None, Found, NotFound }
    private CustomerState _customerState = CustomerState.None;
    private string _resolvedCustomerName = string.Empty;

    // Customer card controls
    private RoundedTextBox _textCustomerPhone = null!;
    private Label _labelCustomerStatus = null!;
    private RoundedButton _buttonLookup = null!;
    private RoundedButton _buttonEditCustomer = null!;
    private RoundedButton _buttonCustomerAction = null!;

    // Cart
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

        // Lookup events
        KeyPreview = true;
        KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter && _textCustomerPhone.ContainsFocus)
            {
                e.SuppressKeyPress = true;
                _presenter.LookupCustomer(_textCustomerPhone.Text.Trim());
            }
        };
        _buttonLookup.Click += (_, _) => _presenter.LookupCustomer(_textCustomerPhone.Text.Trim());
        _textCustomerPhone.TextChanged += (_, _) =>
        {
            if (_customerState != CustomerState.None)
                ClearCustomerStatus();
        };
        _buttonCustomerAction.Click += OnCustomerActionClicked;
        _buttonEditCustomer.Click += OnEditCustomerClicked;

        // Cart / totals events
        _buttonAddMedicine.Click += (_, _) => _presenter.AddMedicineToCart();
        _buttonRemoveItem.Click += (_, _) => RemoveSelectedCartItem();
        _numDiscount.ValueChanged += (_, _) => _presenter.RefreshTotals();
        _numDiscount.Leave += (_, _) =>
        {
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
        this.WireClickOutsideToBlur();
    }

    // ─── IInvoiceEditorView ────────────────────────────────────────────────

    public string CustomerName => _resolvedCustomerName;
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

    public void ShowCustomerFound(CustomerLookupDTO customer)
    {
        _resolvedCustomerName = customer.Name;
        _customerState = CustomerState.Found;

        var historyText = customer.InvoiceCount > 0
            ? $"  ·  {customer.InvoiceCount} lần  ·  {customer.TotalPurchases:N0} đ"
            : "  ·  Chưa có hóa đơn";

        _labelCustomerStatus.Text = $"✓  {customer.Name}{historyText}";
        _labelCustomerStatus.ForeColor = Color.FromArgb(25, 135, 84);

        _buttonEditCustomer.Visible = true;

        _buttonCustomerAction.Text = "Đặt lại";
        _buttonCustomerAction.BackColor = Color.FromArgb(108, 117, 125);
        _buttonCustomerAction.HoverBackColor = Color.FromArgb(88, 96, 105);
        _buttonCustomerAction.Visible = true;
    }

    public void ShowCustomerNotFound(string phone)
    {
        _resolvedCustomerName = string.Empty;
        _customerState = CustomerState.NotFound;

        _labelCustomerStatus.Text = "Chưa có trong hệ thống";
        _labelCustomerStatus.ForeColor = Color.FromArgb(200, 110, 0);

        _buttonEditCustomer.Visible = false;

        _buttonCustomerAction.Text = "Tạo mới";
        _buttonCustomerAction.BackColor = Color.FromArgb(0, 123, 255);
        _buttonCustomerAction.HoverBackColor = Color.FromArgb(0, 105, 217);
        _buttonCustomerAction.Visible = true;
    }

    public void ClearCustomerStatus()
    {
        _resolvedCustomerName = string.Empty;
        _customerState = CustomerState.None;
        _labelCustomerStatus.Text = "Nhập SĐT rồi nhấn Tìm hoặc Enter";
        _labelCustomerStatus.ForeColor = Color.FromArgb(150, 150, 150);
        _buttonEditCustomer.Visible = false;
        _buttonCustomerAction.Visible = false;
    }

    public void ResetForm(string newInvoiceCode)
    {
        _labelInvoiceCode.Text = $"Mã hóa đơn: {newInvoiceCode}";
        _textCustomerPhone.Text = string.Empty;
        ClearCustomerStatus();
        _numDiscount.Value = 0;
        _textNote.Text = string.Empty;
        _cartItems.Clear();
        RefreshCartGrid();
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
            return null;

        foreach (var newItem in picker.SelectedItems)
        {
            var existing = _cartItems.FirstOrDefault(d => d.MedicineId == newItem.MedicineId);
            if (existing is not null)
                existing.Quantity += newItem.Quantity;
            else
                _cartItems.Add(newItem);
        }

        RefreshCartGrid();
        return picker.SelectedItems;
    }

    // ─── Private helpers ───────────────────────────────────────────────────

    private void OnCustomerActionClicked(object? sender, EventArgs e)
    {
        if (_customerState == CustomerState.NotFound)
        {
            var phone = _textCustomerPhone.Text.Trim();
            using var dialog = new CreateCustomerDialog(phone);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                _resolvedCustomerName = dialog.CustomerName;
                _customerState = CustomerState.Found;
                _labelCustomerStatus.Text = $"✓  {dialog.CustomerName}  ·  Khách hàng mới";
                _labelCustomerStatus.ForeColor = Color.FromArgb(25, 135, 84);
                _buttonEditCustomer.Visible = true;
                _buttonCustomerAction.Text = "Đặt lại";
                _buttonCustomerAction.BackColor = Color.FromArgb(108, 117, 125);
                _buttonCustomerAction.HoverBackColor = Color.FromArgb(88, 96, 105);
            }
        }
        else if (_customerState == CustomerState.Found)
        {
            _textCustomerPhone.Text = string.Empty;
            ClearCustomerStatus();
        }
    }

    private void OnEditCustomerClicked(object? sender, EventArgs e)
    {
        var currentPhone = _textCustomerPhone.Text.Trim();
        using var dialog = new EditCustomerDialog(_resolvedCustomerName, currentPhone);
        if (dialog.ShowDialog(this) != DialogResult.OK) return;

        _resolvedCustomerName = dialog.CustomerName;
        _textCustomerPhone.Text = dialog.CustomerPhone;

        _labelCustomerStatus.Text = $"✓  {dialog.CustomerName}  ·  {dialog.CustomerPhone}";
        _labelCustomerStatus.ForeColor = Color.FromArgb(25, 135, 84);
    }

    private void RemoveSelectedCartItem()
    {
        if (_cartGrid.CurrentRow?.Tag is not InvoiceDetailInputDTO item) return;
        _cartItems.Remove(item);
        RefreshCartGrid();
    }

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

        _presenter.RefreshTotals();
    }

    // ─── Layout ────────────────────────────────────────────────────────────

    private void InitializeLayout(string staffName)
    {
        Text = "Lập hóa đơn";
        ClientSize = new Size(1020, 700);
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
            AutoSize = false,
            AutoEllipsis = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(180, 215, 255),
            Location = new Point(672, 26),
            Size = new Size(220, 22),
            TextAlign = ContentAlignment.MiddleRight,
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

        // ── Customer info card (phone-first lookup) ───────────────────────────
        var cardCustomer = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(24, 20),
            Size = new Size(480, 130),
            Padding = new Padding(20, 14, 20, 14)
        };

        var labelCustTitle = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(20, 14),
            Text = "Thông tin khách hàng"
        };

        var labelCustPhone = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(20, 54),
            Text = "SĐT:"
        };

        _textCustomerPhone = new RoundedTextBox
        {
            BorderColor = Color.FromArgb(170, 183, 196),
            BorderRadius = 8,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(56, 50),
            PlaceholderText = "Nhập số điện thoại...",
            Size = new Size(244, 32)
        };

        _buttonLookup = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 86, 179),
            BorderRadius = 8,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 70, 155),
            Location = new Point(308, 50),
            Size = new Size(76, 32),
            Text = "Tìm"
        };
        _buttonLookup.FlatAppearance.BorderSize = 0;

        _labelCustomerStatus = new Label
        {
            AutoSize = false,
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(150, 150, 150),
            Location = new Point(20, 95),
            Size = new Size(236, 22),
            Text = "Nhập SĐT rồi nhấn Tìm hoặc Enter",
            TextAlign = ContentAlignment.MiddleLeft
        };

        _buttonEditCustomer = new RoundedButton
        {
            BackColor = Color.FromArgb(23, 162, 184),
            BorderRadius = 8,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(18, 140, 160),
            Location = new Point(264, 91),
            Size = new Size(62, 28),
            Text = "Sửa",
            Visible = false
        };
        _buttonEditCustomer.FlatAppearance.BorderSize = 0;

        _buttonCustomerAction = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 8,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 105, 217),
            Location = new Point(334, 91),
            Size = new Size(118, 28),
            Text = "Tạo mới",
            Visible = false
        };
        _buttonCustomerAction.FlatAppearance.BorderSize = 0;

        cardCustomer.Controls.AddRange([labelCustTitle, labelCustPhone, _textCustomerPhone, _buttonLookup, _labelCustomerStatus, _buttonEditCustomer, _buttonCustomerAction]);

        // ── Note card ───────────────────────────────────────────────────────
        var cardNote = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(516, 20),
            Size = new Size(480, 130),
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
            Size = new Size(440, 52)
        };

        cardNote.Controls.AddRange([labelNoteTitle, _textNote]);

        // ── Cart section ─────────────────────────────────────────────────────
        var cardCart = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Location = new Point(24, 158),
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
            AllowUserToResizeColumns = false,
            AllowUserToResizeRows = false,
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
        foreach (DataGridViewColumn col in _cartGrid.Columns)
            col.SortMode = DataGridViewColumnSortMode.NotSortable;

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
            Size = new Size(972, 118),
            Padding = new Padding(24, 12, 24, 12)
        };

        // Hàng 1: tổng phụ + giảm giá
        _labelTotal = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(20, 14),
            Text = "Tổng tiền hàng: 0 đ"
        };

        var labelDiscountLbl = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(264, 14),
            Text = "Giảm giá (đ):"
        };

        _numDiscount = new NumericUpDown
        {
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(370, 10),
            Maximum = 999_999_999,
            Minimum = 0,
            Size = new Size(128, 28),
            ThousandsSeparator = true,
            Value = 0
        };

        _labelDiscount = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(220, 53, 69),
            Location = new Point(508, 14),
            Text = "Giảm giá: 0 đ"
        };

        // Hàng 2: thanh toán + nút lưu
        var labelFinalLbl = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Location = new Point(20, 58),
            Text = "THANH TOÁN:"
        };

        _labelFinal = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(0, 123, 255),
            Location = new Point(150, 52),
            Text = "0 đ"
        };

        _buttonSave = new RoundedButton
        {
            BackColor = Color.FromArgb(40, 167, 69),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(33, 150, 60),
            Location = new Point(840, 50),
            Size = new Size(120, 54),
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
