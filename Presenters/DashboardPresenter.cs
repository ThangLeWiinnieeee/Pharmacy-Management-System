using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class DashboardPresenter
{
    private readonly IDashboardBLL _dashboardBLL;
    private readonly IRevenueBLL _revenueBLL;
    private readonly IDashboardView _dashboardView;

    public DashboardPresenter(IDashboardView dashboardView)
        : this(dashboardView, new DashboardBLL(new DashboardDAL()), new RevenueBLL())
    {
    }

    public DashboardPresenter(IDashboardView dashboardView, IDashboardBLL dashboardBLL, IRevenueBLL revenueBLL)
    {
        _dashboardView = dashboardView;
        _dashboardBLL = dashboardBLL;
        _revenueBLL = revenueBLL;
    }

    public void LoadDashboard()
    {
        try
        {
            var stats = _dashboardBLL.GetStats();
            _dashboardView.ShowDashboardStats(stats);

            var year = DateTime.Today.Year;
            var monthlyRevenue = _revenueBLL.GetMonthlyRevenue(year);
            _dashboardView.ShowMonthlyRevenue(monthlyRevenue, year);
        }
        catch
        {
            _dashboardView.ShowDashboardError("Không thể tải dữ liệu dashboard. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }
}
