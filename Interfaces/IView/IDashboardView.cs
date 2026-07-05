using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IDashboardView
{
    void ShowDashboardStats(DashboardStatsDTO stats);

    /// <summary>Vẽ biểu đồ tổng doanh thu 12 tháng của năm</summary>
    void ShowMonthlyRevenue(IReadOnlyList<MonthlyRevenuePointDTO> points, int year);

    void ShowDashboardError(string message);
}
