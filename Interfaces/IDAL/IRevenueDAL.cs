using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IDAL;

public interface IRevenueDAL
{
    /// <summary>Doanh thu từng nhân viên trong một tháng</summary>
    List<EmployeeRevenueDTO> GetEmployeeRevenue(int year, int month);

    /// <summary>Tổng doanh thu 12 tháng của một năm (cho biểu đồ)</summary>
    List<MonthlyRevenuePointDTO> GetMonthlyRevenue(int year);

    /// <summary>Ngày của hóa đơn hoàn tất gần nhất, null nếu chưa có hóa đơn nào</summary>
    DateTime? GetLatestInvoiceDate();
}
