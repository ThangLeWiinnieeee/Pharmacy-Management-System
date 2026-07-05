using System.Globalization;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

/// <summary>
/// Popup tổng kết sau khi bấm "Thanh toán": liệt kê sản phẩm, tình trạng đã thanh toán, số tiền;
/// có nút "Lưu hóa đơn" (lưu DB) và "In hóa đơn" (in bản đã thanh toán, cần trả 0đ).
/// </summary>
public class PaymentSummaryDialog : Form
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    private readonly Func<OperationResultDTO> _save;
    private readonly string _staff;
    private readonly string _customer;
    private readonly string _phone;
    private readonly IReadOnlyList<InvoiceDetailInputDTO> _items;
    private readonly decimal _total;
    private readonly int _pointsUsed;
    private readonly decimal _final;

    private string _code;
    private bool _saved;

    private RoundedButton _buttonSave = null!;

    /// <summary>Đã lưu hóa đơn vào DB hay chưa (form cha dùng để reset khi đóng).</summary>
    public bool WasSaved => _saved;

    public PaymentSummaryDialog(
        Func<OperationResultDTO> save,
        string provisionalCode,
        string staff,
        string customer,
        string phone,
        IReadOnlyList<InvoiceDetailInputDTO> items,
        decimal total,
        int pointsUsed,
        decimal final)
    {
        _save = save;
        _code = provisionalCode;
        _staff = staff;
        _customer = string.IsNullOrWhiteSpace(customer) ? "Khách lẻ" : customer;
        _phone = phone;
        _items = items;
        _total = total;
        _pointsUsed = pointsUsed;
        _final = final;

        BuildUI();
    }

    private void BuildUI()
    {
        Text = "Tổng kết thanh toán";
        ClientSize = new Size(560, 620);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        // ── Header trạng thái ────────────────────────────────────────────────
        var header = new Panel
        {
            BackColor = Color.FromArgb(40, 167, 69),
            Dock = DockStyle.Top,
            Height = 72
        };
        var labelStatus = new Label
        {
            AutoSize = false,
            Dock = DockStyle.Fill,
            Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleCenter,
            Text = "✓  ĐÃ THANH TOÁN"
        };
        header.Controls.Add(labelStatus);

        // ── Nút dưới ─────────────────────────────────────────────────────────
        var footer = new Panel { Dock = DockStyle.Bottom, Height = 76, Padding = new Padding(20, 14, 20, 14) };

        _buttonSave = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 105, 217),
            Location = new Point(20, 16),
            Size = new Size(180, 46),
            Text = "Lưu hóa đơn"
        };
        _buttonSave.FlatAppearance.BorderSize = 0;
        _buttonSave.Click += OnSaveClicked;

        var buttonPrint = new RoundedButton
        {
            BackColor = Color.FromArgb(108, 117, 125),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(88, 96, 105),
            Location = new Point(212, 16),
            Size = new Size(160, 46),
            Text = "In hóa đơn"
        };
        buttonPrint.FlatAppearance.BorderSize = 0;
        buttonPrint.Click += (_, _) => PrintReceipt();

        var buttonClose = new RoundedButton
        {
            BackColor = Color.FromArgb(233, 236, 239),
            BorderRadius = 12,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            HoverBackColor = Color.FromArgb(218, 222, 226),
            Location = new Point(384, 16),
            Size = new Size(136, 46),
            Text = "Đóng"
        };
        buttonClose.FlatAppearance.BorderSize = 0;
        buttonClose.Click += (_, _) => Close();

        footer.Controls.AddRange([_buttonSave, buttonPrint, buttonClose]);

        // ── Thân: thông tin + danh sách + số tiền ────────────────────────────
        var body = new Panel { Dock = DockStyle.Fill, Padding = new Padding(20, 16, 20, 8), BackColor = Color.FromArgb(248, 249, 250) };

        var labelInfo = new Label
        {
            AutoSize = false,
            Dock = DockStyle.Top,
            Height = 52,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Text = $"Mã hóa đơn: {_code}\nNhân viên: {_staff}     Khách hàng: {_customer}" +
                   (string.IsNullOrWhiteSpace(_phone) ? "" : $"  ·  {_phone}")
        };

        var grid = new DataGridView
        {
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            ColumnHeadersHeight = 34,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            Dock = DockStyle.Fill,
            EnableHeadersVisualStyles = false,
            GridColor = Color.FromArgb(233, 236, 239),
            MultiSelect = false,
            ReadOnly = true,
            RowHeadersVisible = false,
            RowTemplate = { Height = 32 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tên thuốc", FillWeight = 50, ReadOnly = true });
        grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL", FillWeight = 14, ReadOnly = true });
        grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Thành tiền", FillWeight = 36, ReadOnly = true });
        foreach (DataGridViewColumn c in grid.Columns) c.SortMode = DataGridViewColumnSortMode.NotSortable;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 244, 248);
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        grid.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        grid.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        foreach (var item in _items)
        {
            grid.Rows.Add(item.MedicineName, item.Quantity.ToString("N0", Vi), $"{item.LineTotal.ToString("N0", Vi)} đ");
        }

        var totals = new Panel { Dock = DockStyle.Bottom, Height = 96, BackColor = Color.FromArgb(248, 249, 250) };
        var labelTotal = new Label
        {
            AutoSize = false, Dock = DockStyle.Top, Height = 24,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            TextAlign = ContentAlignment.MiddleRight,
            Text = $"Tổng tiền hàng: {_total.ToString("N0", Vi)} đ"
        };
        var labelPoints = new Label
        {
            AutoSize = false, Dock = DockStyle.Top, Height = 24,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(220, 53, 69),
            TextAlign = ContentAlignment.MiddleRight,
            Text = $"Trừ điểm: {_pointsUsed.ToString("N0", Vi)} đ",
            Visible = _pointsUsed > 0
        };
        var labelPaid = new Label
        {
            AutoSize = false, Dock = DockStyle.Top, Height = 40,
            Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(40, 167, 69),
            TextAlign = ContentAlignment.MiddleRight,
            Text = $"Đã thanh toán: {_final.ToString("N0", Vi)} đ"
        };
        totals.Controls.Add(labelPaid);
        totals.Controls.Add(labelPoints);
        totals.Controls.Add(labelTotal);

        body.Controls.Add(grid);
        body.Controls.Add(totals);
        body.Controls.Add(labelInfo);

        Controls.Add(body);
        Controls.Add(footer);
        Controls.Add(header);
    }

    private void OnSaveClicked(object? sender, EventArgs e)
    {
        if (_saved)
        {
            MessageBox.Show(this, "Hóa đơn đã được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var result = _save();
        if (!result.IsSuccess)
        {
            MessageBox.Show(this, result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _saved = true;
        if (!string.IsNullOrWhiteSpace(result.InvoiceCode))
        {
            _code = result.InvoiceCode!;
        }
        _buttonSave.Text = "Đã lưu ✓";
        _buttonSave.Enabled = false;
        MessageBox.Show(this, result.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void PrintReceipt()
    {
        using var doc = new InvoiceReceiptDocument(
            _code, DateTime.Now, _staff, _customer, _phone,
            _items.ToList(), _total, 0m, _pointsUsed, _final, paid: true);
        using var preview = new PrintPreviewDialog { Document = doc, WindowState = FormWindowState.Maximized };
        preview.ShowDialog(this);
    }
}
