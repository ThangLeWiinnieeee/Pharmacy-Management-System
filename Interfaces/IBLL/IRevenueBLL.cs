using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface IRevenueBLL
{
    List<EmployeeRevenueDTO> GetEmployeeRevenue(int year, int month);

    List<MonthlyRevenuePointDTO> GetMonthlyRevenue(int year);

    DateTime? GetLatestInvoiceDate();
}
