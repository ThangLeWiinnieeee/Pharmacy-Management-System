using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class RevenueReportPresenter
{
    private readonly IRevenueReportView _view;
    private readonly IRevenueBLL _revenueBLL;

    public RevenueReportPresenter(IRevenueReportView view)
        : this(view, new RevenueBLL())
    {
    }

    public RevenueReportPresenter(IRevenueReportView view, IRevenueBLL revenueBLL)
    {
        _view = view;
        _revenueBLL = revenueBLL;
    }

    /// <summary>Mở trang: nhảy tới tháng gần nhất có dữ liệu rồi tải báo cáo.</summary>
    public void LoadLatest()
    {
        try
        {
            var latest = _revenueBLL.GetLatestInvoiceDate();
            if (latest.HasValue)
            {
                _view.SetPeriod(latest.Value.Year, latest.Value.Month);
            }
        }
        catch
        {
            // Không lấy được tháng gần nhất thì cứ dùng tháng đang chọn
        }

        LoadReport();
    }

    public void LoadReport()
    {
        try
        {
            var rows = _revenueBLL.GetEmployeeRevenue(_view.SelectedYear, _view.SelectedMonth);
            var total = rows.Sum(r => r.Revenue);
            _view.ShowEmployeeRevenue(rows, total);
        }
        catch (Exception ex)
        {
            _view.ShowError("Không thể tải dữ liệu doanh thu.\nChi tiết: " + ex.Message);
        }
    }
}
