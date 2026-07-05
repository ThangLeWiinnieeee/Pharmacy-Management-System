using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.DAL;

public class RevenueDAL : IRevenueDAL
{
    private const string CompletedStatus = "Completed";

    public List<EmployeeRevenueDTO> GetEmployeeRevenue(int year, int month)
    {
        using var context = new AppDbContext();

        var from = new DateTime(year, month, 1);
        var to = from.AddMonths(1);

        var revenueByUser = context.Invoices
            .Where(i => i.Status == CompletedStatus && i.CreatedAt >= from && i.CreatedAt < to)
            .GroupBy(i => i.CreatedByUserId)
            .Select(g => new { UserId = g.Key, Revenue = g.Sum(i => i.FinalAmount), Count = g.Count() })
            .ToList()
            .ToDictionary(x => x.UserId);

        var users = context.Users
            .Where(u => u.IsActive)
            .Select(u => new { u.Id, u.FullName, u.Username, u.Role })
            .ToList();

        return users
            .Select(u =>
            {
                var found = revenueByUser.TryGetValue(u.Id, out var r) ? r : null;
                return new EmployeeRevenueDTO
                {
                    UserId = u.Id,
                    FullName = u.FullName,
                    Username = u.Username,
                    Role = u.Role,
                    InvoiceCount = found?.Count ?? 0,
                    Revenue = found?.Revenue ?? 0
                };
            })
            .OrderByDescending(e => e.Revenue)
            .ThenBy(e => e.FullName)
            .ToList();
    }

    public List<MonthlyRevenuePointDTO> GetMonthlyRevenue(int year)
    {
        using var context = new AppDbContext();

        var start = new DateTime(year, 1, 1);
        var end = start.AddYears(1);

        var byMonth = context.Invoices
            .Where(i => i.Status == CompletedStatus && i.CreatedAt >= start && i.CreatedAt < end)
            .GroupBy(i => i.CreatedAt.Month)
            .Select(g => new { Month = g.Key, Revenue = g.Sum(i => i.FinalAmount) })
            .ToList()
            .ToDictionary(x => x.Month);

        return Enumerable.Range(1, 12)
            .Select(m => new MonthlyRevenuePointDTO
            {
                Month = m,
                Revenue = byMonth.TryGetValue(m, out var r) ? r.Revenue : 0
            })
            .ToList();
    }

    public DateTime? GetLatestInvoiceDate()
    {
        using var context = new AppDbContext();
        return context.Invoices
            .Where(i => i.Status == CompletedStatus)
            .Select(i => (DateTime?)i.CreatedAt)
            .Max();
    }
}
