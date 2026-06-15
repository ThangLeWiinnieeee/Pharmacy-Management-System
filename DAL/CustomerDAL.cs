using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.DAL;

public class CustomerDAL : ICustomerDAL
{
    public CustomerLookupDTO? LookupByPhone(string phone)
    {
        using var db = new AppDbContext();

        var customer = db.Customers.FirstOrDefault(c => c.Phone == phone);

        var invoices = db.Invoices
            .Where(i => i.CustomerPhone == phone)
            .OrderByDescending(i => i.CreatedAt)
            .ToList();

        if (customer == null && invoices.Count == 0) return null;

        var name = customer?.Name
            ?? invoices.FirstOrDefault()?.CustomerName
            ?? phone;

        return new CustomerLookupDTO
        {
            Name = name,
            Phone = phone,
            TotalPurchases = invoices.Sum(i => i.FinalAmount),
            InvoiceCount = invoices.Count
        };
    }

    public void CreateCustomer(string name, string phone, string? address)
    {
        using var db = new AppDbContext();
        if (db.Customers.Any(c => c.Phone == phone)) return;

        db.Customers.Add(new Customer
        {
            Name = name,
            Phone = phone,
            Address = string.IsNullOrWhiteSpace(address) ? null : address.Trim()
        });
        db.SaveChanges();
    }

    public void UpdateCustomer(string currentPhone, string newName, string newPhone, string? newAddress)
    {
        using var db = new AppDbContext();
        var customer = db.Customers.FirstOrDefault(c => c.Phone == currentPhone);
        if (customer is not null)
        {
            customer.Name = newName;
            customer.Phone = newPhone;
            customer.Address = string.IsNullOrWhiteSpace(newAddress) ? null : newAddress.Trim();
            db.SaveChanges();
        }
        else if (!db.Customers.Any(c => c.Phone == newPhone))
        {
            db.Customers.Add(new Customer
            {
                Name = newName,
                Phone = newPhone,
                Address = string.IsNullOrWhiteSpace(newAddress) ? null : newAddress.Trim()
            });
            db.SaveChanges();
        }
    }

    public IReadOnlyList<CustomerListDTO> GetAll(string keyword)
    {
        using var db = new AppDbContext();

        var query = db.Customers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var kw = keyword.Trim().ToLower();
            query = query.Where(c => c.Name.ToLower().Contains(kw)
                                  || (c.Phone != null && c.Phone.Contains(kw)));
        }

        var customers = query.OrderByDescending(c => c.CreatedAt).ToList();
        if (customers.Count == 0) return [];

        var phones = customers.Where(c => c.Phone != null).Select(c => c.Phone!).ToList();

        var summaries = phones.Count > 0
            ? db.Invoices
                .Where(i => i.CustomerPhone != null && phones.Contains(i.CustomerPhone))
                .GroupBy(i => i.CustomerPhone!)
                .Select(g => new { Phone = g.Key, Total = g.Sum(i => i.FinalAmount), Count = g.Count() })
                .ToList()
            : [];

        var summaryByPhone = summaries.ToDictionary(x => x.Phone);

        return customers.Select(c =>
        {
            var s = c.Phone is not null && summaryByPhone.TryGetValue(c.Phone, out var found) ? found : null;
            return new CustomerListDTO
            {
                Id = c.Id,
                Name = c.Name,
                Phone = c.Phone,
                Address = c.Address,
                CreatedAt = c.CreatedAt,
                TotalPurchases = s?.Total ?? 0,
                InvoiceCount = s?.Count ?? 0
            };
        }).ToList();
    }

    public void DeleteCustomer(int id)
    {
        using var db = new AppDbContext();
        var customer = db.Customers.Find(id);
        if (customer is null) return;
        db.Customers.Remove(customer);
        db.SaveChanges();
    }
}
