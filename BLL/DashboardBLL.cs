using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class DashboardBLL : IDashboardBLL
{
    private readonly IDashboardDAL _dashboardDAL;

    public DashboardBLL(IDashboardDAL dashboardDAL)
    {
        _dashboardDAL = dashboardDAL;
    }

    public DashboardStatsDTO GetStats()
    {
        return _dashboardDAL.GetStats();
    }
}
