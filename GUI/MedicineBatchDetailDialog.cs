using System.Globalization;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

/// <summary>
/// Dialog hiển thị danh sách lô nhập của một mã thuốc.
/// Mỗi lô có: ngày nhập, số lượng nhập, hạn dùng, trạng thái.
/// Cho phép thêm lô mới qua AddBatchDialog.
/// </summary>
public class MedicineBatchDetailDialog : Form
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    private readonly MedicineBatchDAL _dal = new();
    private readonly MedicineDTO _medicine;
    private readonly bool _isAdmin;

    private DataGridView _grid = null!;
    private Label _lblGiaNhap = null!;
    private Label _lblGhiChu  = null!;
    private RoundedButton _btnAddBatch  = null!;
    private RoundedButton _btnEditBatch = null!;

    public bool NeedRefresh { get; private set; }

    public MedicineBatchDetailDialog(MedicineDTO medicine, bool isAdmin = false)
    {
        _medicine = medicine;
        _isAdmin  = isAdmin;
        BuildDialog();
        LoadBatches();
    }

    private void BuildDialog()
    {
        Text = $"Lô hàng — {_medicine.Name}";
        ClientSize = new Size(760, 540);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = MinimizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        // ── Header ────────────────────────────────────────────────────────────
        var header = new Panel { BackColor = Color.FromArgb(0, 86, 179), Dock = DockStyle.Top, Height = 68 };
        header.Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White,
            Location = new Point(24, 10),
            Text = _medicine.Name
        });
        header.Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(180, 215, 255),
            Location = new Point(26, 40),
            Text = $"Mã: {_medicine.Code}  ·  ĐVT: {_medicine.Unit}  ·  Tồn kho hiện tại: {_medicine.Quantity:N0}"
        });

        // ── Footer ─────────────────────────────────────────────────────────────
        var footer = new Panel { BackColor = Color.White, Dock = DockStyle.Bottom, Height = 60 };
        footer.Paint += (_, e) =>
        {
            using var p = new Pen(Color.FromArgb(224, 229, 235));
            e.Graphics.DrawLine(p, 0, 0, footer.Width, 0);
        };

        var btnClose = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 86, 179), BorderRadius = 10, BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White, HoverBackColor = Color.FromArgb(0, 70, 150),
            Location = new Point(760 - 24 - 140, 11), Size = new Size(140, 38), Text = "Đóng"
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Click += (_, _) => Close();

        _btnAddBatch = new RoundedButton
        {
            BackColor = Color.FromArgb(40, 167, 69), BorderRadius = 10, BorderSize = 0,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White, HoverBackColor = Color.FromArgb(33, 150, 60),
            Location = new Point(24, 11), Size = new Size(170, 38), Text = "+ Nhập thêm lô",
            Visible = _isAdmin
        };
        _btnAddBatch.FlatAppearance.BorderSize = 0;
        _btnAddBatch.Click += OnAddBatch;

        _btnEditBatch = new RoundedButton
        {
            BackColor = Color.FromArgb(0, 123, 180), BorderRadius = 10, BorderSize = 0,
            Enabled = false,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.White, HoverBackColor = Color.FromArgb(0, 100, 155),
            Location = new Point(202, 11), Size = new Size(120, 38), Text = "✏️ Sửa lô",
            Visible = _isAdmin
        };
        _btnEditBatch.FlatAppearance.BorderSize = 0;
        _btnEditBatch.Click += OnEditBatch;

        footer.Controls.AddRange([_btnAddBatch, _btnEditBatch, btnClose]);

        // ── Body ──────────────────────────────────────────────────────────────
        var body = new Panel { BackColor = Color.FromArgb(248, 249, 250), Dock = DockStyle.Fill };

        // Card
        var card = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 14, BorderSize = 1,
            Location = new Point(16, 12),
            Size = new Size(728, 398)
        };

        // Card title
        card.Controls.Add(new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(0, 86, 179),
            Location = new Point(16, 14),
            Text = "📦 Danh sách lô nhập"
        });

        // Grid
        _grid = new DataGridView
        {
            AllowUserToAddRows = false, AllowUserToDeleteRows = false,
            AllowUserToResizeColumns = false, AllowUserToResizeRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White, BorderStyle = BorderStyle.None,
            ColumnHeadersHeight = 36,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            EnableHeadersVisualStyles = false,
            GridColor = Color.FromArgb(233, 236, 239),
            Location = new Point(16, 44), MultiSelect = false,
            ReadOnly = true, RowHeadersVisible = false,
            RowTemplate = { Height = 34 },
            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            Size = new Size(696, 266)
        };

        var h = _grid.ColumnHeadersDefaultCellStyle;
        h.BackColor = Color.FromArgb(240, 244, 248);
        h.ForeColor = Color.FromArgb(51, 51, 51);
        h.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
        h.SelectionBackColor = h.BackColor; h.SelectionForeColor = h.ForeColor;
        _grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(218, 236, 255);
        _grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 86, 179);
        _grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);

        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Lô #",      Name = "colNum",    FillWeight = 8,  ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Ngày nhập", Name = "colDate",   FillWeight = 18, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "SL nhập",   Name = "colQty",    FillWeight = 13, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Hạn dùng",  Name = "colExpiry", FillWeight = 18, ReadOnly = true });
        _grid.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Trạng thái lô", Name = "colStatus", FillWeight = 20, ReadOnly = true });

        foreach (DataGridViewColumn col in _grid.Columns)
            col.SortMode = DataGridViewColumnSortMode.NotSortable;

        _grid.SelectionChanged += OnSelectionChanged;

        // Detail strip (below grid)
        var divider = new Panel
        {
            BackColor = Color.FromArgb(224, 229, 235),
            Location = new Point(16, 318), Size = new Size(696, 1)
        };

        _lblGiaNhap = new Label
        {
            AutoSize = true,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(16, 327),
            Text = "Giá nhập: —"
        };

        _lblGhiChu = new Label
        {
            AutoSize = false,
            Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(80, 80, 80),
            Location = new Point(16, 352),
            Size = new Size(696, 36),
            Text = "Ghi chú: —"
        };

        card.Controls.AddRange([_grid, divider, _lblGiaNhap, _lblGhiChu]);
        body.Controls.Add(card);

        Controls.Add(body);
        Controls.Add(footer);
        Controls.Add(header);
    }

    private void LoadBatches()
    {
        var batches = _dal.GetByMedicineId(_medicine.Id);
        _grid.Rows.Clear();

        int lotNum = batches.Count;
        foreach (var b in batches)
        {
            var (statusText, statusColor) = GetBatchStatus(b.ExpiryDate);

            var idx = _grid.Rows.Add(
                lotNum.ToString(),
                b.ImportDate.ToString("dd/MM/yyyy"),
                b.ImportQuantity.ToString("N0", Vi),
                b.ExpiryDate.HasValue ? b.ExpiryDate.Value.ToString("dd/MM/yyyy") : "Không có",
                statusText);

            var row = _grid.Rows[idx];
            row.Tag = b;
            row.Cells["colStatus"].Style.ForeColor = statusColor;
            row.Cells["colStatus"].Style.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            row.Cells["colNum"].Style.ForeColor = Color.FromArgb(100, 100, 100);

            // Tô nền cho lô hết hạn / sắp hết hạn
            if (b.ExpiryDate.HasValue)
            {
                var diff = (b.ExpiryDate.Value.Date - DateTime.Today).TotalDays;
                if (diff < 0)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 245, 245);
                else if (diff < 90)
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 252, 240);
            }

            lotNum--;
        }

        _btnEditBatch.Enabled = false;
        UpdateDetailStrip(null);
    }

    private void OnSelectionChanged(object? sender, EventArgs e)
    {
        var b = _grid.CurrentRow?.Tag as MedicineBatchDTO;
        _btnEditBatch.Enabled = b is not null;
        UpdateDetailStrip(b);
    }

    private void UpdateDetailStrip(MedicineBatchDTO? b)
    {
        if (b is null)
        {
            _lblGiaNhap.Text = "Giá nhập: —";
            _lblGhiChu.Text  = "Ghi chú: —";
        }
        else
        {
            _lblGiaNhap.Text = $"Giá nhập: {b.ImportPrice:N0} đ";
            _lblGhiChu.Text  = $"Ghi chú: {(string.IsNullOrWhiteSpace(b.Note) ? "—" : b.Note)}";
        }
    }

    private void OnAddBatch(object? sender, EventArgs e)
    {
        using var dlg = new AddBatchDialog(_medicine);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        NeedRefresh = true;
        LoadBatches();
    }

    private void OnEditBatch(object? sender, EventArgs e)
    {
        if (_grid.CurrentRow?.Tag is not MedicineBatchDTO b) return;
        using var dlg = new EditBatchDialog(b, _medicine);
        if (dlg.ShowDialog(this) != DialogResult.OK) return;
        NeedRefresh = true;
        LoadBatches();
    }

    private static (string text, Color color) GetBatchStatus(DateTime? expiryDate)
    {
        if (!expiryDate.HasValue)
            return ("Không xác định", Color.FromArgb(130, 130, 130));

        var diff = (expiryDate.Value.Date - DateTime.Today).TotalDays;
        return diff switch
        {
            < 0   => ("Hết hạn",     Color.FromArgb(140, 20, 40)),
            < 90  => ("Sắp hết hạn", Color.FromArgb(200, 100, 0)),
            _     => ("Còn hạn",     Color.FromArgb(25, 135, 84))
        };
    }
}
