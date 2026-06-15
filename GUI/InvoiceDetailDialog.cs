using System.Globalization;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

public class InvoiceDetailDialog : Form
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    public InvoiceDetailDialog(InvoiceDTO invoice)
    {
        SuspendLayout();
        BuildDialog(invoice);
        ResumeLayout(false);
    }

    private void BuildDialog(InvoiceDTO invoice)
    {
        Text = $"Chi tiết hóa đơn  –  {invoice.InvoiceCode}";
        Size = new Size(760, 580);
        MinimumSize = new Size(660, 480);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.Sizable;
        MaximizeBox = true;
        MinimizeBox = false;
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9.5f, FontStyle.Regular, GraphicsUnit.Point);

        var root = new Panel { Dock = DockStyle.Fill, Padding = new Padding(16) };
        Controls.Add(root);

        // --- Footer (bottom): totals + close button ---
        var footer = new Panel { Dock = DockStyle.Bottom, Height = 68, BackColor = Color.Transparent };
        root.Controls.Add(footer);

        var btnClose = new RoundedButton
        {
            Text = "Đóng",
            Size = new Size(108, 38),
            BackColor = Color.FromArgb(108, 117, 125),
            HoverBackColor = Color.FromArgb(88, 96, 105),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            BorderRadius = 12,
            BorderSize = 0,
            Font = new Font("Segoe UI", 10f, FontStyle.Bold, GraphicsUnit.Point),
            Anchor = AnchorStyles.Top | AnchorStyles.Right
        };
        btnClose.FlatAppearance.BorderSize = 0;
        btnClose.Location = new Point(footer.Width - 108, 15);
        btnClose.Click += (_, _) => Close();
        footer.Controls.Add(btnClose);
        footer.SizeChanged += (_, _) => btnClose.Location = new Point(footer.Width - 108, 15);

        var panelTotals = BuildTotalsPanel(invoice);
        panelTotals.Location = new Point(0, 15);
        panelTotals.Height = 38;
        panelTotals.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        panelTotals.Width = Math.Max(0, footer.Width - 120);
        footer.Controls.Add(panelTotals);
        footer.SizeChanged += (_, _) => panelTotals.Width = Math.Max(0, footer.Width - 120);

        // --- Gap ---
        root.Controls.Add(new Panel { Dock = DockStyle.Bottom, Height = 10, BackColor = Color.Transparent });

        // --- Details panel (fill) ---
        var panelDetails = new RoundedPanel
        {
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 16,
            BorderSize = 1,
            Padding = new Padding(16, 12, 16, 16)
        };
        root.Controls.Add(panelDetails);

        var grid = BuildGrid();
        panelDetails.Controls.Add(grid);

        var lblDetailTitle = new Label
        {
            Text = $"Danh sách thuốc  ({invoice.Details.Count} mặt hàng)",
            Font = new Font("Segoe UI", 10.5f, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Dock = DockStyle.Top,
            Height = 32,
            BackColor = Color.Transparent
        };
        panelDetails.Controls.Add(lblDetailTitle);

        foreach (var d in invoice.Details)
        {
            grid.Rows.Add(
                d.MedicineCode,
                d.MedicineName,
                d.Unit,
                d.Quantity.ToString("N0", Vi),
                FormatMoney(d.UnitPrice),
                FormatMoney(d.LineTotal));
        }

        // --- Gap ---
        root.Controls.Add(new Panel { Dock = DockStyle.Top, Height = 10, BackColor = Color.Transparent });

        // --- Info panel (top) ---
        root.Controls.Add(BuildInfoPanel(invoice));
    }

    private static RoundedPanel BuildInfoPanel(InvoiceDTO invoice)
    {
        var panel = new RoundedPanel
        {
            Dock = DockStyle.Top,
            Height = 112,
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 16,
            BorderSize = 1,
            Padding = new Padding(20, 12, 20, 10)
        };

        var lblTitle = new Label
        {
            Text = "Thông tin hóa đơn",
            Font = new Font("Segoe UI", 11f, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(51, 51, 51),
            Dock = DockStyle.Top,
            Height = 26,
            BackColor = Color.Transparent
        };
        panel.Controls.Add(lblTitle);

        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2,
            BackColor = Color.Transparent,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4f));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));

        var emp = string.IsNullOrWhiteSpace(invoice.CreatedByFullName) ? "Không rõ" : invoice.CreatedByFullName;
        table.Controls.Add(InfoCell("Mã hóa đơn", invoice.InvoiceCode), 0, 0);
        table.Controls.Add(InfoCell("Ngày tạo", invoice.CreatedAt.ToString("dd/MM/yyyy  HH:mm", Vi)), 1, 0);
        table.Controls.Add(InfoCell("Nhân viên tạo", emp), 2, 0);

        var customer = string.IsNullOrWhiteSpace(invoice.CustomerName) ? "Khách lẻ" : invoice.CustomerName.Trim();
        table.Controls.Add(InfoCell("Khách hàng", customer), 0, 1);
        table.Controls.Add(InfoCell("Số điện thoại", invoice.CustomerPhone ?? "—"), 1, 1);

        var statusText = invoice.Status switch
        {
            "Completed" => "Hoàn tất",
            "Cancelled"  => "Đã hủy",
            _            => string.IsNullOrWhiteSpace(invoice.Status) ? "Không rõ" : invoice.Status
        };
        var statusColor = invoice.Status == "Cancelled"
            ? Color.FromArgb(220, 53, 69)
            : Color.FromArgb(40, 167, 69);
        table.Controls.Add(InfoCell("Trạng thái", statusText, statusColor), 2, 1);

        panel.Controls.Add(table);
        return panel;
    }

    private static Panel InfoCell(string label, string value, Color? valueColor = null)
    {
        var cell = new Panel { BackColor = Color.Transparent };

        var lblLabel = new Label
        {
            Text = label,
            Font = new Font("Segoe UI", 8f, FontStyle.Regular, GraphicsUnit.Point),
            ForeColor = Color.FromArgb(102, 102, 102),
            Location = new Point(0, 2),
            AutoSize = false,
            Height = 16
        };

        var lblValue = new Label
        {
            Text = value,
            Font = new Font("Segoe UI", 9.5f, FontStyle.Bold, GraphicsUnit.Point),
            ForeColor = valueColor ?? Color.FromArgb(51, 51, 51),
            Location = new Point(0, 20),
            AutoSize = false,
            Height = 20,
            AutoEllipsis = true
        };

        cell.Controls.Add(lblLabel);
        cell.Controls.Add(lblValue);

        cell.SizeChanged += (_, _) =>
        {
            var w = Math.Max(0, cell.Width - 8);
            lblLabel.Width = w;
            lblValue.Width = w;
        };

        return cell;
    }

    private static RoundedPanel BuildTotalsPanel(InvoiceDTO invoice)
    {
        var panel = new RoundedPanel
        {
            BackColor = Color.White,
            BorderColor = Color.FromArgb(224, 229, 235),
            BorderRadius = 12,
            BorderSize = 1
        };

        var table = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 2,
            BackColor = Color.Transparent,
            CellBorderStyle = TableLayoutPanelCellBorderStyle.None
        };
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3f));
        table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4f));
        table.RowStyles.Add(new RowStyle(SizeType.Absolute, 16f));
        table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));

        table.Controls.Add(TotalLabel("Tiền hàng",  8.5f, Color.FromArgb(102, 102, 102)), 0, 0);
        table.Controls.Add(TotalLabel("Giảm giá",   8.5f, Color.FromArgb(102, 102, 102)), 1, 0);
        table.Controls.Add(TotalLabel("Thanh toán", 8.5f, Color.FromArgb(51, 51, 51)),    2, 0);

        table.Controls.Add(TotalLabel(invoice.TotalAmount.ToString("N0", Vi),  10f, Color.FromArgb(51, 51, 51),    FontStyle.Bold), 0, 1);
        table.Controls.Add(TotalLabel(invoice.Discount.ToString("N0", Vi),     10f, Color.FromArgb(220, 53, 69),  FontStyle.Bold), 1, 1);
        table.Controls.Add(TotalLabel(invoice.FinalAmount.ToString("N0", Vi),  11f, Color.FromArgb(0, 123, 255),  FontStyle.Bold), 2, 1);

        panel.Controls.Add(table);
        return panel;
    }

    private static Label TotalLabel(string text, float size, Color color, FontStyle style = FontStyle.Regular)
    {
        return new Label
        {
            Text = text,
            Font = new Font("Segoe UI", size, style, GraphicsUnit.Point),
            ForeColor = color,
            Dock = DockStyle.Fill,
            TextAlign = ContentAlignment.MiddleLeft,
            BackColor = Color.Transparent,
            Padding = new Padding(10, 0, 0, 0)
        };
    }

    private static DataGridView BuildGrid()
    {
        var grid = new DataGridView
        {
            Dock = DockStyle.Fill,
            AllowUserToAddRows = false,
            AllowUserToDeleteRows = false,
            AllowUserToResizeRows = false,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            BackgroundColor = Color.White,
            BorderStyle = BorderStyle.None,
            ColumnHeadersHeight = 36,
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
            ReadOnly = true,
            RowHeadersVisible = false,
            MultiSelect = false,
            SelectionMode = DataGridViewSelectionMode.FullRowSelect
        };
        grid.RowTemplate.Height = 34;

        grid.EnableHeadersVisualStyles = false;
        grid.GridColor = Color.FromArgb(233, 236, 239);
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Bold, GraphicsUnit.Point);
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular, GraphicsUnit.Point);
        grid.DefaultCellStyle.ForeColor = Color.FromArgb(51, 51, 51);
        grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 239, 255);
        grid.DefaultCellStyle.SelectionForeColor = Color.FromArgb(51, 51, 51);
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(252, 253, 255);

        grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Code",      HeaderText = "Mã thuốc",   FillWeight = 88f,  ReadOnly = true, SortMode = DataGridViewColumnSortMode.NotSortable });
        grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name",      HeaderText = "Tên thuốc",  FillWeight = 195f, ReadOnly = true, SortMode = DataGridViewColumnSortMode.NotSortable });
        grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Unit",      HeaderText = "Đơn vị",     FillWeight = 68f,  ReadOnly = true, SortMode = DataGridViewColumnSortMode.NotSortable });
        grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qty",       HeaderText = "Số lượng",   FillWeight = 76f,  ReadOnly = true, SortMode = DataGridViewColumnSortMode.NotSortable });
        grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Đơn giá",    FillWeight = 98f,  ReadOnly = true, SortMode = DataGridViewColumnSortMode.NotSortable });
        grid.Columns.Add(new DataGridViewTextBoxColumn { Name = "LineTotal", HeaderText = "Thành tiền", FillWeight = 110f, ReadOnly = true, SortMode = DataGridViewColumnSortMode.NotSortable });

        return grid;
    }

    private string FormatMoney(decimal value) => value.ToString("N0", Vi);
}
