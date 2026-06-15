using System.Globalization;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class InvoiceHistoryView : UserControl, IInvoiceHistoryView
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");
    private readonly InvoiceHistoryPresenter _presenter;
    private bool _isInitializing = true;

    public InvoiceHistoryView()
    {
        InitializeComponent();

        _presenter = new InvoiceHistoryPresenter(this);
        comboStatusFilter.SelectedIndex = 0;
        dateFromPicker.Checked = false;
        dateToPicker.Checked = false;
        _isInitializing = false;

        Load += (_, _) => _presenter.LoadInvoices();
        textSearchInvoice.TextChanged += (_, _) => RequestReload();
        comboStatusFilter.SelectedIndexChanged += (_, _) => RequestReload();
        dateFromPicker.ValueChanged += (_, _) => RequestReload();
        dateToPicker.ValueChanged += (_, _) => RequestReload();
        buttonRefresh.Click += (_, _) => _presenter.LoadInvoices();
        invoicesGrid.CellContentClick += OnViewDetailClick;
    }

    public string SearchKeyword => textSearchInvoice.Text.Trim();

    public string StatusFilter
    {
        get
        {
            return comboStatusFilter.SelectedItem?.ToString() switch
            {
                "Hoàn tất" => "Completed",
                "Đã hủy" => "Cancelled",
                _ => "Tất cả"
            };
        }
    }

    public DateTime? DateFrom => dateFromPicker.Checked ? dateFromPicker.Value.Date : null;

    public DateTime? DateTo => dateToPicker.Checked ? dateToPicker.Value.Date : null;

    public InvoiceDTO? SelectedInvoice
    {
        get
        {
            if (invoicesGrid.CurrentRow?.Tag is InvoiceDTO invoice)
                return invoice;
            return null;
        }
    }

    public void ShowInvoices(IReadOnlyList<InvoiceDTO> invoices)
    {
        invoicesGrid.SuspendLayout();
        invoicesGrid.Rows.Clear();

        foreach (var invoice in invoices)
        {
            var rowIndex = invoicesGrid.Rows.Add(
                invoice.CreatedAt.ToString("dd/MM/yyyy HH:mm", Vi),
                invoice.InvoiceCode,
                FormatCustomer(invoice),
                invoice.CustomerPhone ?? string.Empty,
                string.IsNullOrWhiteSpace(invoice.CreatedByFullName) ? "Không rõ" : invoice.CreatedByFullName,
                FormatMoney(invoice.TotalAmount),
                FormatMoney(invoice.Discount),
                FormatMoney(invoice.FinalAmount));

            invoicesGrid.Rows[rowIndex].Tag = invoice;
        }

        if (invoicesGrid.Rows.Count > 0)
        {
            invoicesGrid.ClearSelection();
            invoicesGrid.Rows[0].Selected = true;
            invoicesGrid.CurrentCell = invoicesGrid.Rows[0].Cells[0];
        }

        invoicesGrid.ResumeLayout();
    }

    public void ShowInvoiceDetails(InvoiceDTO? invoice) { }

    public void ShowSummary(int invoiceCount, decimal totalAmount, decimal discount, decimal finalAmount, int itemCount)
    {
        labelInvoiceCountValue.Text = invoiceCount.ToString("N0", Vi);
        labelTotalAmountValue.Text = FormatMoney(totalAmount);
        labelDiscountValue.Text = FormatMoney(discount);
        labelFinalAmountValue.Text = FormatMoney(finalAmount);
        labelItemCountValue.Text = itemCount.ToString("N0", Vi);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Lịch sử bán hàng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void OnViewDetailClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (e.ColumnIndex != invoicesGrid.Columns["columnViewDetail"]?.Index) return;
        if (invoicesGrid.Rows[e.RowIndex].Tag is InvoiceDTO invoice)
        {
            using var dialog = new InvoiceDetailDialog(invoice);
            dialog.ShowDialog(this);
        }
    }

    private void RequestReload()
    {
        if (_isInitializing) return;
        _presenter.LoadInvoices();
    }

    private static string FormatMoney(decimal value) => value.ToString("N0", Vi);

    private static string FormatCustomer(InvoiceDTO invoice)
    {
        return string.IsNullOrWhiteSpace(invoice.CustomerName)
            ? "Khách lẻ"
            : invoice.CustomerName.Trim();
    }
}
