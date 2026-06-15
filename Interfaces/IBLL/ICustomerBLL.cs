using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface ICustomerBLL
{
    CustomerLookupDTO? LookupByPhone(string phone);
    void CreateCustomer(string name, string phone, string? address);
    void UpdateCustomer(string currentPhone, string newName, string newPhone, string? newAddress);
    IReadOnlyList<CustomerListDTO> GetAll(string keyword);
    void DeleteCustomer(int id);
}
