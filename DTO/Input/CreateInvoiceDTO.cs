namespace PharmacyManagementSystem.DTO.Input;

/// <summary>Toàn bộ thông tin để lập một hóa đơn bán thuốc</summary>
public class CreateInvoiceDTO
{
    public int CreatedByUserId { get; set; }

    /// <summary>Tên khách hàng (nhập tay, không bắt buộc)</summary>
    public string? CustomerName { get; set; }

    /// <summary>SĐT khách hàng (nhập tay, không bắt buộc)</summary>
    public string? CustomerPhone { get; set; }

    public decimal Discount { get; set; }

    /// <summary>Số điểm khách muốn dùng để trừ tiền (1 điểm = 1đ). Chỉ áp dụng khi có khách hàng.</summary>
    public int PointsUsed { get; set; }

    public string? Note { get; set; }

    public List<InvoiceDetailInputDTO> Details { get; set; } = [];
}
