using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IInvoiceHistoryView
{
    string SearchKeyword { get; }

    string StatusFilter { get; }

    DateTime? DateFrom { get; }

    DateTime? DateTo { get; }

    InvoiceDTO? SelectedInvoice { get; }

    void ShowInvoices(IReadOnlyList<InvoiceDTO> invoices);

    void ShowInvoiceDetails(InvoiceDTO? invoice);

    void ShowSummary(int invoiceCount, decimal totalAmount, decimal discount, decimal finalAmount, int itemCount);

    void ShowError(string message);
}
