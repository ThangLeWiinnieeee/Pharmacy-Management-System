using System.Globalization;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

/// <summary>
/// Dialog chọn thuốc 2 cột:
/// Trái  – danh sách thuốc (tick chọn nhiều)
/// Phải  – giỏ hàng tích hợp nhập số lượng inline
///
/// Luồng: ① Tick thuốc → ② Thêm vào giỏ → ③ Chỉnh số lượng trực tiếp trong giỏ → ④ Xác nhận
/// </summary>
public class MedicinePickerDialog : Form
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");
    private const int FormW = 1060, FormH = 692, CardH = 550, LeftW = 560, RightW = 460;

    private readonly IReadOnlyList<MedicineDTO> _medicines;
    private readonly List<InvoiceDetailInputDTO> _cartItems = [];

    // Left
    private readonly RoundedTextBox _textSearch;
    private readonly DataGridView   _medicineGrid;
    private readonly Label          _labelStock, _labelPrice;
    private readonly RoundedButton  _btnAddToCart;

    // Right – cart (có cột SL chỉnh được)
    private readonly DataGridView  _cartGrid;
    private readonly Label         _labelCartSummary;
    private readonly RoundedButton _btnRemove, _btnConfirm, _btnCancel;

    public IReadOnlyList<InvoiceDetailInputDTO> SelectedItems => _cartItems.AsReadOnly();
    public InvoiceDetailInputDTO? SelectedItem => _cartItems.Count > 0 ? _cartItems[0] : null;

    public MedicinePickerDialog(IReadOnlyList<MedicineDTO> medicines)
    {
        _medicines = medicines;
        Text = "Chọn thuốc thêm vào hóa đơn";
        ClientSize = new Size(FormW, FormH);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        // ── Header ──────────────────────────────────────────────────────────
        var header = new Panel { BackColor = Color.FromArgb(0, 86, 179), Dock = DockStyle.Top, Height = 62 };
        header.Controls.Add(Lbl("Chọn thuốc thêm vào hóa đơn", 14, bold: true, white: true, loc: new Point(24, 10)));
        header.Controls.Add(Lbl("① Tick chọn thuốc  →  ② Thêm vào giỏ  →  ③ Chỉnh số lượng trong giỏ  →  ④ Xác nhận",
            9, bold: false, white: false, loc: new Point(26, 38), color: Color.FromArgb(180, 215, 255)));

        // ── Footer ───────────────────────────────────────────────────────────
        var footer = new Panel { BackColor = Color.White, Dock = DockStyle.Bottom, Height = 64 };
        footer.Paint += (_, e) => { using var p = new Pen(Color.FromArgb(224, 229, 235)); e.Graphics.DrawLine(p, 0, 0, footer.Width, 0); };

        _btnConfirm = MakeBtn("✔ Thêm vào hóa đơn", Color.FromArgb(40, 167, 69), Color.FromArgb(33, 150, 60),
            new Point(FormW - 24 - 180, 13), new Size(180, 38));
        _btnConfirm.Enabled = false;
        _btnConfirm.Click += (_, _) => { if (_cartItems.Count > 0) { DialogResult = DialogResult.OK; Close(); } };

        _btnCancel = MakeBtn("Hủy", Color.FromArgb(248, 249, 250), Color.FromArgb(230, 235, 240),
            new Point(FormW - 24 - 180 - 8 - 90, 13), new Size(90, 38));
        _btnCancel.ForeColor = Color.FromArgb(80, 80, 80);
        _btnCancel.BorderColor = Color.FromArgb(200, 210, 220);
        _btnCancel.BorderSize = 1;
        _btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        footer.Controls.AddRange([_btnCancel, _btnConfirm]);

        // ── Body ─────────────────────────────────────────────────────────────
        var body = new Panel { BackColor = Color.FromArgb(248, 249, 250), Dock = DockStyle.Fill };

        // ══ LEFT CARD ═══════════════════════════════════════════════════════
        var cL = Card(new Point(12, 10), new Size(LeftW, CardH));

        cL.Controls.Add(Lbl("① Danh sách thuốc", 10, bold: true, loc: new Point(14, 14)));
        cL.Controls.Add(Lbl("(✓ tick để chọn nhiều)", 8.5f, loc: new Point(180, 17), color: Color.FromArgb(102, 102, 102)));

        _textSearch = new RoundedTextBox
        {
            BorderColor = Color.FromArgb(170, 183, 196), BorderRadius = 9,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(14, 40), Size = new Size(LeftW - 28, 34),
            PlaceholderText = "Tên hoặc mã thuốc..."
        };
        _textSearch.TextChanged += (_, _) => ApplyFilter();
        cL.Controls.Add(_textSearch);

        _medicineGrid = MakeGrid(new Point(14, 84), new Size(LeftW - 28, 380), multiSelect: true, readOnly: false);
        _medicineGrid.AllowUserToResizeColumns = false;
        _medicineGrid.AllowUserToResizeRows    = false;
        _medicineGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        _medicineGrid.Columns.Add(new DataGridViewCheckBoxColumn
            { HeaderText = "", Name = "colCheck", Width = 36, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, ReadOnly = false });
        _medicineGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Mã",          Name = "colCode",  FillWeight = 12, ReadOnly = true });
        _medicineGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc",   Name = "colName",  FillWeight = 35, ReadOnly = true });
        _medicineGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ĐVT",         Name = "colUnit",  FillWeight = 9,  ReadOnly = true });
        _medicineGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tồn kho",     Name = "colStock", FillWeight = 11, ReadOnly = true });
        _medicineGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Giá bán (đ)", Name = "colPrice", FillWeight = 14, ReadOnly = true });
        _medicineGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái",  Name = "colStatus",FillWeight = 17, ReadOnly = true });
        // Khóa sort để tránh thay đổi thứ tự bất ngờ
        foreach (DataGridViewColumn col in _medicineGrid.Columns)
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
        _medicineGrid.SelectionChanged += OnMedSelChanged;
        _medicineGrid.CellContentClick += OnCheckboxClick;
        _medicineGrid.CellDoubleClick  += (_, e) => { if (e.ColumnIndex != _medicineGrid.Columns["colCheck"]!.Index) ToggleCheck(); };
        cL.Controls.Add(_medicineGrid);

        _labelStock = Lbl("Tồn kho: --", 9, loc: new Point(14, 475), color: Color.FromArgb(102, 102, 102));
        _labelPrice = Lbl("Giá bán: --", 9, loc: new Point(140, 475), color: Color.FromArgb(0, 123, 255));
        cL.Controls.Add(_labelStock);
        cL.Controls.Add(_labelPrice);

        _btnAddToCart = MakeBtn("② Thêm vào giỏ hàng →", Color.FromArgb(0, 123, 255), Color.FromArgb(0, 113, 235),
            new Point(LeftW - 28 - 210, 508), new Size(210, 38));
        _btnAddToCart.Enabled = false;
        _btnAddToCart.Click += (_, _) => AddCheckedToCart();
        cL.Controls.Add(_btnAddToCart);

        // ══ RIGHT CARD ══════════════════════════════════════════════════════
        var cR = Card(new Point(12 + LeftW + 10, 10), new Size(RightW, CardH));

        cR.Controls.Add(Lbl("③ Giỏ hàng – Chỉnh số lượng trực tiếp", 10, bold: true, loc: new Point(14, 14)));

        _labelCartSummary = Lbl("Chưa có mặt hàng nào", 9, loc: new Point(14, 38), color: Color.FromArgb(102, 102, 102));
        cR.Controls.Add(_labelCartSummary);

        // Cart grid: cột SL được chỉnh inline
        _cartGrid = MakeGrid(new Point(14, 60), new Size(RightW - 28, 420), multiSelect: false, readOnly: false);
        _cartGrid.AllowUserToResizeColumns = false;
        _cartGrid.AllowUserToResizeRows    = false;
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc",      Name = "cName",  FillWeight = 42, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tồn",            Name = "cStock", FillWeight = 16, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL ✏",           Name = "cQty",   FillWeight = 14, ReadOnly = false });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Đơn giá",        Name = "cPrice", FillWeight = 18, ReadOnly = true });
        _cartGrid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền",     Name = "cTotal", FillWeight = 20, ReadOnly = true });
        _cartGrid.CellEndEdit           += OnCartCellEndEdit;
        _cartGrid.EditingControlShowing += OnCartEditShowing;
        cR.Controls.Add(_cartGrid);

        _btnRemove = MakeBtn("Xóa dòng", Color.FromArgb(220, 53, 69), Color.FromArgb(200, 43, 58),
            new Point(14, 492), new Size(110, 34));
        _btnRemove.Click += (_, _) => RemoveCartItem();
        cR.Controls.Add(_btnRemove);

        body.Controls.AddRange([cL, cR]);
        Controls.Add(body);
        Controls.Add(footer);
        Controls.Add(header);

        LoadMedicineGrid(_medicines);
        this.WireClickOutsideToBlur();
    }

    // ─── UI helpers ────────────────────────────────────────────────────────

    private static Label Lbl(string text, float size = 9.5f, bool bold = false, bool white = false,
        Point loc = default, Color color = default)
    {
        return new Label
        {
            AutoSize  = true,
            Font      = new Font("Segoe UI", size, bold ? FontStyle.Bold : FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = white ? Color.White : (color == default ? Color.FromArgb(51, 51, 51) : color),
            Location  = loc,
            Text      = text
        };
    }

    private static RoundedPanel Card(Point loc, Size size) => new()
    {
        BackColor = Color.White, BorderColor = Color.FromArgb(224, 229, 235),
        BorderRadius = 14, BorderSize = 1, Location = loc, Size = size
    };

    private static RoundedButton MakeBtn(string text, Color back, Color hover, Point loc, Size size)
    {
        var b = new RoundedButton
        {
            BackColor = back, BorderRadius = 10, BorderSize = 0, FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White, HoverBackColor = hover, Location = loc, Size = size, Text = text
        };
        b.FlatAppearance.BorderSize = 0;
        return b;
    }

    private static DataGridView MakeGrid(Point loc, Size size, bool multiSelect, bool readOnly)
    {
        var g = new DataGridView
        {
            AllowUserToAddRows = false, AllowUserToDeleteRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
            ColumnHeadersHeight = 36, ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            EnableHeadersVisualStyles = false, GridColor = Color.FromArgb(233, 236, 239),
            Location = loc, MultiSelect = multiSelect, ReadOnly = readOnly,
            RowHeadersVisible = false, RowTemplate = { Height = 34 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect, Size = size
        };
        var h = g.ColumnHeadersDefaultCellStyle;
        h.BackColor = Color.FromArgb(240, 244, 248); h.ForeColor = Color.FromArgb(51, 51, 51);
        h.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        h.SelectionBackColor = h.BackColor; h.SelectionForeColor = h.ForeColor;
        g.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 236, 255);
        g.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 86, 179);
        g.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        return g;
    }

    // ─── Medicine list ──────────────────────────────────────────────────────

    private void LoadMedicineGrid(IEnumerable<MedicineDTO> list)
    {
        _medicineGrid.Rows.Clear();
        foreach (var m in list)
        {
            bool inCart    = _cartItems.Any(c => c.MedicineId == m.Id);
            var  status    = MedicineStatusHelper.Evaluate(m);
            bool canSelect = status.CanOrder;

            var idx = _medicineGrid.Rows.Add(
                canSelect && inCart ? true : (object)(canSelect ? inCart : false),
                m.Code, m.Name, m.Unit,
                m.Quantity > 0 ? m.Quantity.ToString("N0", Vi) : "0",
                m.SellPrice.ToString("N0", Vi),
                status.Text);

            var row = _medicineGrid.Rows[idx];
            row.Tag = m;

            // Màu chữ hàng — mờ nếu không thể đặt
            row.DefaultCellStyle.ForeColor = canSelect
                ? Color.FromArgb(51, 51, 51)
                : Color.FromArgb(160, 150, 150);

            row.Cells["colStatus"].Style.ForeColor = status.ForeColor;
            row.Cells["colStatus"].Style.Font      = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);

            // Tô màu cột hạn dùng
            if (m.ExpiryDate.HasValue)
            {
                var diff = (m.ExpiryDate.Value.Date - DateTime.Today).TotalDays;
                if (diff < 0)
                    row.Cells["colPrice"].Style.ForeColor = Color.FromArgb(200, 200, 200); // giá mờ nếu hết hạn
                // (không có cột ExpDate trong picker — bỏ qua)
            }

            // Vô hiệu hóa checkbox cho thuốc không thể chọn
            if (!canSelect)
            {
                var chkCell = (DataGridViewCheckBoxCell)row.Cells["colCheck"];
                chkCell.Value    = false;
                chkCell.ReadOnly = true;
                chkCell.Style.BackColor = Color.FromArgb(245, 245, 245);
            }
        }
        RefreshAddButton();
    }


    private void ApplyFilter()
    {
        var kw = _textSearch.Text.Trim().ToLowerInvariant();
        var src = string.IsNullOrEmpty(kw) ? _medicines
            : (IEnumerable<MedicineDTO>)_medicines.Where(m =>
                m.Code.ToLowerInvariant().Contains(kw) ||
                m.Name.ToLowerInvariant().Contains(kw)).ToList();
        LoadMedicineGrid(src);
    }

    private void OnMedSelChanged(object? sender, EventArgs e)
    {
        if (_medicineGrid.CurrentRow?.Tag is MedicineDTO m)
        {
            _labelStock.Text = $"Tồn kho: {m.Quantity:N0}";
            _labelPrice.Text = $"Giá bán: {m.SellPrice:N0} đ";
        }
        else { _labelStock.Text = "Tồn kho: --"; _labelPrice.Text = "Giá bán: --"; }
    }

    private void OnCheckboxClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex != _medicineGrid.Columns["colCheck"]!.Index) return;
        _medicineGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        RefreshAddButton();
    }

    private void ToggleCheck()
    {
        if (_medicineGrid.CurrentRow is null) return;
        var cell = _medicineGrid.CurrentRow.Cells["colCheck"];
        cell.Value = !Convert.ToBoolean(cell.Value);
        _medicineGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
        RefreshAddButton();
    }

    private void RefreshAddButton()
    {
        _btnAddToCart.Enabled = _medicineGrid.Rows.Cast<DataGridViewRow>()
            .Any(r => Convert.ToBoolean(r.Cells["colCheck"].Value)
                   && r.Tag is MedicineDTO m && m.IsActive && m.Quantity > 0
                   && !_cartItems.Any(c => c.MedicineId == m.Id));
    }

    // ─── Cart (add / edit qty / remove) ───────────────────────────────────

    /// <summary>
    /// Thêm tất cả dòng đã tick (chưa trong giỏ) vào giỏ hàng với SL mặc định = 1.
    /// Người dùng chỉnh SL trực tiếp trong cart grid.
    /// </summary>
    private void AddCheckedToCart()
    {
        bool added = false;
        foreach (DataGridViewRow row in _medicineGrid.Rows)
        {
            if (!Convert.ToBoolean(row.Cells["colCheck"].Value)) continue;
            if (row.Tag is not MedicineDTO m || m.Quantity <= 0) continue;
            if (_cartItems.Any(c => c.MedicineId == m.Id)) continue;    // đã có → bỏ qua

            _cartItems.Add(new InvoiceDetailInputDTO
            {
                MedicineId   = m.Id,   MedicineCode = m.Code,
                MedicineName = m.Name, Unit         = m.Unit,
                Quantity     = 1,      UnitPrice    = m.SellPrice,
                // lưu tồn kho để clamp khi chỉnh SL
            });

            // Đính kèm tồn kho vào DTO tạm thời bằng cách dùng Tag riêng
            // (xem OnCartCellEndEdit – lấy lại từ _medicines)
            added = true;
        }

        if (added)
        {
            RefreshCartGrid();
            ApplyFilter();          // cập nhật tick + màu left grid
        }
    }

    private void RemoveCartItem()
    {
        if (_cartGrid.CurrentRow?.Tag is not InvoiceDetailInputDTO item) return;
        _cartItems.Remove(item);
        ApplyFilter();
        RefreshCartGrid();
    }

    private void RefreshCartGrid()
    {
        _cartGrid.Rows.Clear();
        foreach (var item in _cartItems)
        {
            var med   = _medicines.FirstOrDefault(m => m.Id == item.MedicineId);
            var stock = med?.Quantity ?? item.Quantity;
            var idx   = _cartGrid.Rows.Add(
                item.MedicineName,
                stock.ToString("N0", Vi),
                item.Quantity.ToString(),
                item.UnitPrice.ToString("N0", Vi),
                item.LineTotal.ToString("N0", Vi));
            _cartGrid.Rows[idx].Tag = item;
        }

        var total = _cartItems.Sum(d => d.LineTotal);
        _labelCartSummary.Text = _cartItems.Count == 0
            ? "Chưa có mặt hàng nào"
            : $"{_cartItems.Count} mặt hàng · Tổng: {total:N0} đ";
        _btnConfirm.Enabled = _cartItems.Count > 0;
        RefreshAddButton();
    }

    // ─── Cart inline qty editing ───────────────────────────────────────────

    private void OnCartCellEndEdit(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != _cartGrid.Columns["cQty"]!.Index) return;
        if (_cartGrid.Rows[e.RowIndex].Tag is not InvoiceDetailInputDTO item) return;

        var cell = _cartGrid.Rows[e.RowIndex].Cells["cQty"];
        var raw  = cell.Value?.ToString()?.Trim() ?? "";

        if (!int.TryParse(raw, out var qty) || qty < 1)
            qty = 1;

        // Clamp theo tồn kho
        var med = _medicines.FirstOrDefault(m => m.Id == item.MedicineId);
        if (med is not null && qty > med.Quantity)
            qty = med.Quantity;

        item.Quantity   = qty;
        cell.Value      = qty.ToString();   // không format N0 để tránh parse lại bị lỗi

        // Cập nhật thành tiền và tổng
        _cartGrid.Rows[e.RowIndex].Cells["cTotal"].Value = item.LineTotal.ToString("N0", Vi);
        var total = _cartItems.Sum(d => d.LineTotal);
        _labelCartSummary.Text = $"{_cartItems.Count} mặt hàng · Tổng: {total:N0} đ";
    }

    private void OnCartEditShowing(object? sender, DataGridViewEditingControlShowingEventArgs e)
    {
        if (_cartGrid.CurrentCell?.OwningColumn.Name != "cQty") return;
        if (e.Control is TextBox tb) { tb.KeyPress -= OnQtyKey; tb.KeyPress += OnQtyKey; }
    }

    // ─── Helpers ───────────────────────────────────────────────────────────

    private static void OnQtyKey(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
    }
}
