using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IDashboardView
{
    void ShowDashboardStats(DashboardStatsDTO stats);

    void ShowDashboardError(string message);
}
