using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class RevenueBLL : IRevenueBLL
{
    private readonly IRevenueDAL _revenueDAL;

    public RevenueBLL() : this(new RevenueDAL()) { }

    public RevenueBLL(IRevenueDAL revenueDAL)
    {
        _revenueDAL = revenueDAL;
    }

    public List<EmployeeRevenueDTO> GetEmployeeRevenue(int year, int month)
    {
        if (month < 1 || month > 12)
        {
            return [];
        }

        return _revenueDAL.GetEmployeeRevenue(year, month);
    }

    public List<MonthlyRevenuePointDTO> GetMonthlyRevenue(int year)
    {
        return _revenueDAL.GetMonthlyRevenue(year);
    }

    public DateTime? GetLatestInvoiceDate()
    {
        return _revenueDAL.GetLatestInvoiceDate();
    }
}
