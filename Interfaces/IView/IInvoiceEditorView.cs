using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IInvoiceEditorView
{
    /// <summary>Tên khách hàng đã tra cứu hoặc tạo mới (rỗng = khách lẻ)</summary>
    string CustomerName { get; }

    /// <summary>SĐT khách hàng nhập trên UI</summary>
    string CustomerPhone { get; }

    /// <summary>Số điểm khách chọn dùng để trừ tiền</summary>
    int PointsUsed { get; }

    /// <summary>Ghi chú nhập trên UI</summary>
    string Note { get; }

    /// <summary>Danh sách chi tiết hóa đơn hiện tại</summary>
    IReadOnlyList<InvoiceDetailInputDTO> CartItems { get; }

    void ShowMessage(string message);

    void ShowError(string message);

    bool Confirm(string message);

    /// <summary>Mở popup tổng kết thanh toán (sau khi bấm Thanh toán)</summary>
    void OpenPaymentSummary();

    /// <summary>Bật/tắt nút Thanh toán và In hóa đơn theo việc giỏ hàng có sản phẩm hay không</summary>
    void SetActionsEnabled(bool enabled);

    /// <summary>Làm mới toàn bộ giỏ hàng và form sau khi lưu thành công</summary>
    void ResetForm(string newInvoiceCode);

    /// <summary>Cập nhật hiển thị tổng tiền</summary>
    void RefreshTotals(decimal total, int pointsUsed, decimal finalAmount);

    /// <summary>Mở dialog chọn nhiều thuốc để thêm vào giỏ hàng</summary>
    IReadOnlyList<InvoiceDetailInputDTO>? RequestSelectMedicines();

    /// <summary>Hiện thông tin khách hàng tìm được theo SĐT</summary>
    void ShowCustomerFound(CustomerLookupDTO customer);

    /// <summary>Thông báo SĐT chưa có trong hệ thống</summary>
    void ShowCustomerNotFound(string phone);

    /// <summary>Xóa kết quả tra cứu, về trạng thái ban đầu</summary>
    void ClearCustomerStatus();
}
