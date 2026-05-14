using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class DashboardPresenter
{
    private readonly IDashboardBLL _dashboardBLL;
    private readonly IDashboardView _dashboardView;

    public DashboardPresenter(IDashboardView dashboardView)
        : this(dashboardView, new DashboardBLL(new DashboardDAL()))
    {
    }

    public DashboardPresenter(IDashboardView dashboardView, IDashboardBLL dashboardBLL)
    {
        _dashboardView = dashboardView;
        _dashboardBLL = dashboardBLL;
    }

    public void LoadDashboard()
    {
        try
        {
            var stats = _dashboardBLL.GetStats();
            _dashboardView.ShowDashboardStats(stats);
        }
        catch
        {
            _dashboardView.ShowDashboardError("Không thể tải dữ liệu dashboard. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }
}
