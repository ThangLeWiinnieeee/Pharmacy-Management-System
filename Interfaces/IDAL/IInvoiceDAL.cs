using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IDAL;

public interface IInvoiceDAL
{
    InvoiceDTO Create(CreateInvoiceDTO request);

    List<InvoiceDTO> GetInvoices(InvoiceQueryDTO query);

    List<InvoiceDTO> GetAll();
}
