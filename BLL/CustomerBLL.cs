using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class CustomerBLL : ICustomerBLL
{
    private readonly ICustomerDAL _customerDAL;

    public CustomerBLL() : this(new CustomerDAL()) { }

    public CustomerBLL(ICustomerDAL customerDAL)
    {
        _customerDAL = customerDAL;
    }

    public CustomerLookupDTO? LookupByPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone)) return null;
        return _customerDAL.LookupByPhone(phone.Trim());
    }

    public void CreateCustomer(string name, string phone, string? address)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên khách hàng không được để trống.");
        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Số điện thoại không được để trống.");

        _customerDAL.CreateCustomer(name.Trim(), phone.Trim(), address);
    }

    public void UpdateCustomer(string currentPhone, string newName, string newPhone, string? newAddress)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Tên khách hàng không được để trống.");
        if (string.IsNullOrWhiteSpace(newPhone))
            throw new ArgumentException("Số điện thoại không được để trống.");

        _customerDAL.UpdateCustomer(currentPhone.Trim(), newName.Trim(), newPhone.Trim(), newAddress);
    }

    public IReadOnlyList<CustomerListDTO> GetAll(string keyword)
        => _customerDAL.GetAll(keyword);

    public void DeleteCustomer(int id)
        => _customerDAL.DeleteCustomer(id);
}
