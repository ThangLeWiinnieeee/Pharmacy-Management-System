using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IDAL;

public interface IDashboardDAL
{
    DashboardStatsDTO GetStats();
}
