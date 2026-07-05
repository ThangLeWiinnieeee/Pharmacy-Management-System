using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public class RevenueReportView : UserControl, IRevenueReportView
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    private readonly RevenueReportPresenter _presenter;
    private readonly ComboBox _comboMonth;
    private readonly NumericUpDown _numYear;
    private readonly Label _labelTotal;
    private readonly DataGridView _grid;
    private readonly Label _labelEmpty;
    private bool _initializing = true;

    public RevenueReportView()
    {
        BackColor = Color.FromArgb(248, 249, 250);
        Dock = DockStyle.Fill;

        // ── Thanh lọc tháng/năm ──────────────────────────────────────────────
        var filterCard = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Dock = DockStyle.Top,
            Height = 72,
            Padding = new Padding(20, 0, 20, 0)
        };

        var labelMonth = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(20, 26),
            Text = "Tháng:"
        };

        _comboMonth = new ComboBox
        {
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(78, 22),
            Size = new Size(110, 28)
        };
        for (var m = 1; m <= 12; m++)
        {
            _comboMonth.Items.Add($"Tháng {m}");
        }

        var labelYear = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(212, 26),
            Text = "Năm:"
        };

        _numYear = new NumericUpDown
        {
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            Location = new Point(258, 22),
            Minimum = 2000,
            Maximum = DateTime.Today.Year,
            Size = new Size(90, 28)
        };

        var buttonRefresh = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 255),
            BorderRadius = 10,
            BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            HoverBackColor = Color.FromArgb(0, 105, 217),
            Location = new Point(372, 20),
            Size = new Size(110, 32),
            Text = "Xem báo cáo"
        };
        buttonRefresh.FlatAppearance.BorderSize = 0;

        _labelTotal = new Label
        {
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            AutoSize = false,
            Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(40, 167, 69),
            Location = new Point(520, 22),
            Size = new Size(320, 30),
            TextAlign = ContentAlignment.MiddleRight,
            Text = "Tổng doanh thu: 0 đ"
        };

        filterCard.Controls.AddRange([labelMonth, _comboMonth, labelYear, _numYear, buttonRefresh, _labelTotal]);

        // ── Khoảng đệm ───────────────────────────────────────────────────────
        var gap = new Panel { Dock = DockStyle.Top, Height = 16, BackColor = Color.FromArgb(248, 249, 250) };

        // ── Bảng doanh thu ───────────────────────────────────────────────────
        var gridCard = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14,
            BorderSize = 1,
            Dock = DockStyle.Fill,
            Padding = new Padding(14)
        };

        _grid = new DataGridView
        {
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            ColumnHeadersHeight = 38,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            Dock = DockStyle.Fill,
            EnableHeadersVisualStyles = false,
            GridColor = Color.FromArgb(233, 236, 239),
            MultiSelect = false,
            ReadOnly = true,
            RowHeadersVisible = false,
            RowTemplate = { Height = 36 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };

        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "STT", Name = "colIndex", FillWeight = 8, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Nhân viên", Name = "colName", FillWeight = 30, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Tài khoản", Name = "colUsername", FillWeight = 20, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Vai trò", Name = "colRole", FillWeight = 14, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Số hóa đơn", Name = "colCount", FillWeight = 12, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Doanh thu (đ)", Name = "colRevenue", FillWeight = 16, ReadOnly = true });
        foreach (DataGridViewColumn col in _grid.Columns)
        {
            col.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        var revenueStyle = _grid.Columns["colRevenue"].DefaultCellStyle;
        revenueStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        revenueStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
        _grid.Columns["colCount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        _grid.Columns["colIndex"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        StyleGrid();
        gridCard.Controls.Add(_grid);

        _labelEmpty = new Label
        {
            Dock = DockStyle.Top,
            Height = 34,
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(150, 120, 0),
            TextAlign = ContentAlignment.MiddleCenter,
            Visible = false
        };
        gridCard.Controls.Add(_labelEmpty);

        Controls.Add(gridCard);
        Controls.Add(gap);
        Controls.Add(filterCard);

        _presenter = new RevenueReportPresenter(this);

        var now = DateTime.Today;
        _numYear.Value = now.Year;
        _comboMonth.SelectedIndex = now.Month - 1;
        _initializing = false;

        buttonRefresh.Click += (_, _) => _presenter.LoadReport();
        _comboMonth.SelectedIndexChanged += (_, _) => RequestReload();
        _numYear.ValueChanged += (_, _) => RequestReload();
    }

    public int SelectedYear => (int)_numYear.Value;

    public int SelectedMonth => _comboMonth.SelectedIndex + 1;

    /// <summary>Tải lại báo cáo, tự nhảy tới tháng gần nhất có dữ liệu (gọi khi mở trang)</summary>
    public void Reload() => _presenter.LoadLatest();

    public void SetPeriod(int year, int month)
    {
        _initializing = true;
        if (year >= _numYear.Minimum && year <= _numYear.Maximum)
        {
            _numYear.Value = year;
        }
        if (month >= 1 && month <= 12)
        {
            _comboMonth.SelectedIndex = month - 1;
        }
        _initializing = false;
    }

    public void ShowEmployeeRevenue(IReadOnlyList<EmployeeRevenueDTO> rows, decimal monthTotal)
    {
        _grid.Rows.Clear();

        var index = 1;
        foreach (var row in rows)
        {
            _grid.Rows.Add(
                index++,
                row.FullName,
                row.Username,
                row.Role == "Admin" ? "Quản trị" : "Nhân viên",
                row.InvoiceCount.ToString("N0", Vi),
                row.Revenue.ToString("N0", Vi));
        }

        _labelTotal.Text = $"Tổng doanh thu: {monthTotal.ToString("N0", Vi)} đ";

        var hasData = monthTotal > 0 || rows.Any(r => r.InvoiceCount > 0);
        _labelEmpty.Visible = !hasData;
        _labelEmpty.Text = $"Tháng {SelectedMonth}/{SelectedYear} chưa có hóa đơn nào.";
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Doanh thu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void RequestReload()
    {
        if (_initializing) return;
        ClampMonthToNotFuture();
        _presenter.LoadReport();
    }

    /// <summary>Không cho xem tháng ở tương lai của năm hiện tại; năm trước vẫn xem đủ 12 tháng.</summary>
    private void ClampMonthToNotFuture()
    {
        var now = DateTime.Today;
        if (SelectedYear >= now.Year && SelectedMonth > now.Month)
        {
            _initializing = true;               // chặn RequestReload lồng khi đổi tháng
            _comboMonth.SelectedIndex = now.Month - 1;
            _initializing = false;
        }
    }

    private void StyleGrid()
    {
        var header = _grid.ColumnHeadersDefaultCellStyle;
        header.BackColor = Color.FromArgb(240, 244, 248);
        header.ForeColor = Color.FromArgb(51, 51, 51);
        header.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        header.SelectionBackColor = header.BackColor;
        header.SelectionForeColor = header.ForeColor;

        _grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
        _grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 236, 255);
        _grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 86, 179);
        _grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 253, 255);
    }
}
