using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

/// <summary>
/// Thông tin hiển thị trạng thái thuốc (text + màu chữ + có thể chọn mua không).
/// </summary>
public record MedicineStatusInfo(string Text, Color ForeColor, bool CanOrder);

/// <summary>
/// Tính trạng thái thuốc theo quy tắc nghiệp vụ thống nhất.
/// Dùng chung cho MedicineManagementView và MedicinePickerDialog.
///
/// Thứ tự ưu tiên:
/// 1. Ngừng bán (IsActive = false)
/// 2. Hết hạn   (ExpiryDate đã qua)
/// 3. Đã hết    (Quantity = 0)
/// 4. Sắp hết hạn (ExpiryDate còn dưới 3 tháng)
/// 5. Sắp hết hàng (Quantity < 10)
/// 6. Đang kinh doanh
/// </summary>
public static class MedicineStatusHelper
{
    public const int LowStockThreshold  = 10;
    public const int NearExpiryMonths   = 3;

    public static MedicineStatusInfo Evaluate(MedicineDTO m) =>
        Evaluate(m.IsActive, m.Quantity, m.ExpiryDate);

    public static MedicineStatusInfo Evaluate(bool isActive, int quantity, DateTime? expiryDate)
    {
        var today = DateTime.Today;

        if (!isActive)
            return new("Ngừng bán",    Color.FromArgb(220, 53,  69),  false);

        if (expiryDate.HasValue && expiryDate.Value.Date < today)
            return new("Hết hạn",      Color.FromArgb(140, 20,  40),  false);

        if (quantity <= 0)
            return new("Đã hết",       Color.FromArgb(230, 120,  0),  false);

        if (expiryDate.HasValue && expiryDate.Value.Date < today.AddMonths(NearExpiryMonths))
            return new("Sắp hết hạn",  Color.FromArgb(200, 100,  0),  true);

        if (quantity < LowStockThreshold)
            return new("Sắp hết hàng", Color.FromArgb(230, 140,  0),  true);

        return new("Đang kinh doanh",  Color.FromArgb(40, 167,  69),  true);
    }
}
