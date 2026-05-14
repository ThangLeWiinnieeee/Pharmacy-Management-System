using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface IDashboardBLL
{
    DashboardStatsDTO GetStats();
}
