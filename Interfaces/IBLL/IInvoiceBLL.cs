using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface IInvoiceBLL
{
    OperationResultDTO CreateInvoice(CreateInvoiceDTO request);

    List<InvoiceDTO> GetAll();
}
