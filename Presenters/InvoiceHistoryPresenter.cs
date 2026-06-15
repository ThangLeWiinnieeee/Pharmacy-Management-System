using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class InvoiceHistoryPresenter
{
    private readonly IInvoiceHistoryView _view;
    private readonly IInvoiceBLL _invoiceBLL;

    public InvoiceHistoryPresenter(IInvoiceHistoryView view)
        : this(view, new InvoiceBLL(new InvoiceDAL()))
    {
    }

    public InvoiceHistoryPresenter(IInvoiceHistoryView view, IInvoiceBLL invoiceBLL)
    {
        _view = view;
        _invoiceBLL = invoiceBLL;
    }

    public void LoadInvoices()
    {
        if (_view.DateFrom.HasValue &&
            _view.DateTo.HasValue &&
            _view.DateFrom.Value.Date > _view.DateTo.Value.Date)
        {
            _view.ShowError("Khoảng thời gian không hợp lệ. Ngày bắt đầu phải trước hoặc bằng ngày kết thúc.");
            return;
        }

        try
        {
            var invoices = _invoiceBLL.GetInvoices(new InvoiceQueryDTO
            {
                Keyword = _view.SearchKeyword,
                StatusFilter = _view.StatusFilter,
                DateFrom = _view.DateFrom,
                DateTo = _view.DateTo
            });

            _view.ShowInvoices(invoices);
            ShowSummary(invoices);
            _view.ShowInvoiceDetails(_view.SelectedInvoice);
        }
        catch
        {
            _view.ShowInvoices([]);
            _view.ShowInvoiceDetails(null);
            _view.ShowSummary(0, 0m, 0m, 0m, 0);
            _view.ShowError("Không thể tải lịch sử bán hàng. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public void SelectInvoice()
    {
        _view.ShowInvoiceDetails(_view.SelectedInvoice);
    }

    private void ShowSummary(IReadOnlyList<InvoiceDTO> invoices)
    {
        _view.ShowSummary(
            invoices.Count,
            invoices.Sum(i => i.TotalAmount),
            invoices.Sum(i => i.Discount),
            invoices.Sum(i => i.FinalAmount),
            invoices.Sum(i => i.Details.Sum(d => d.Quantity)));
    }
}
