using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface ICustomerManagementView
{
    string SearchKeyword { get; }
    CustomerListDTO? SelectedCustomer { get; }

    void ShowCustomers(IReadOnlyList<CustomerListDTO> customers);
    bool RequestCustomerAdd();
    bool RequestCustomerEdit(CustomerListDTO customer);
    bool Confirm(string message);
    void ShowMessage(string message);
    void ShowError(string message);
}
