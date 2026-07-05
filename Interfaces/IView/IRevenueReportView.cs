using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IRevenueReportView
{
    int SelectedYear { get; }

    int SelectedMonth { get; }

    /// <summary>Đặt tháng/năm cho bộ lọc (không kích hoạt tải lại)</summary>
    void SetPeriod(int year, int month);

    void ShowEmployeeRevenue(IReadOnlyList<EmployeeRevenueDTO> rows, decimal monthTotal);

    void ShowError(string message);
}
