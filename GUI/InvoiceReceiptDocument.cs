using System.Drawing.Printing;
using System.Globalization;
using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem;

/// <summary>
/// Tài liệu in hóa đơn bán thuốc. Số tiền cần trả = 0 nếu đã thanh toán, ngược lại = thành tiền.
/// ponytail: giả định 1 trang; nếu hóa đơn quá nhiều mặt hàng tràn trang thì bổ sung phân trang (HasMorePages).
/// </summary>
public class InvoiceReceiptDocument : PrintDocument
{
    private static readonly CultureInfo Vi = CultureInfo.GetCultureInfo("vi-VN");

    private readonly string _code;
    private readonly DateTime _time;
    private readonly string _staff;
    private readonly string _customer;
    private readonly string _phone;
    private readonly IReadOnlyList<InvoiceDetailInputDTO> _items;
    private readonly decimal _total;
    private readonly decimal _discount;
    private readonly int _pointsUsed;
    private readonly decimal _final;
    private readonly bool _paid;

    public InvoiceReceiptDocument(
        string code, DateTime time, string staff, string customer, string phone,
        IReadOnlyList<InvoiceDetailInputDTO> items,
        decimal total, decimal discount, int pointsUsed, decimal final, bool paid)
    {
        _code = code;
        _time = time;
        _staff = staff;
        _customer = string.IsNullOrWhiteSpace(customer) ? "Khách lẻ" : customer;
        _phone = phone;
        _items = items;
        _total = total;
        _discount = discount;
        _pointsUsed = pointsUsed;
        _final = final;
        _paid = paid;
        DocumentName = $"Hóa đơn {code}";
    }

    protected override void OnPrintPage(PrintPageEventArgs e)
    {
        base.OnPrintPage(e);
        var g = e.Graphics!;

        using var fontTitle = new Font("Segoe UI", 16f, FontStyle.Bold);
        using var fontSub = new Font("Segoe UI", 10f, FontStyle.Bold);
        using var fontNormal = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        using var fontBold = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        using var fontDue = new Font("Segoe UI", 13f, FontStyle.Bold);
        var brush = Brushes.Black;
        var pen = Pens.Black;
        using var center = new StringFormat { Alignment = StringAlignment.Center };
        using var farRight = new StringFormat { Alignment = StringAlignment.Far };

        float left = e.MarginBounds.Left;
        float right = e.MarginBounds.Right;
        float width = e.MarginBounds.Width;
        float y = e.MarginBounds.Top;

        void Line(string text, Font f) { g.DrawString(text, f, brush, left, y); y += f.Height + 2; }
        void Row(string label, string value, Font f)
        {
            g.DrawString(label, f, brush, left, y);
            g.DrawString(value, f, brush, new RectangleF(left, y, width, f.Height), farRight);
            y += f.Height + 2;
        }
        void Divider() { g.DrawLine(pen, left, y, right, y); y += 6; }

        g.DrawString("NHÀ THUỐC", fontTitle, brush, new RectangleF(left, y, width, fontTitle.Height), center);
        y += fontTitle.Height + 2;
        g.DrawString("HÓA ĐƠN BÁN HÀNG", fontSub, brush, new RectangleF(left, y, width, fontSub.Height), center);
        y += fontSub.Height + 8;

        Row($"Mã HĐ: {_code}", _time.ToString("dd/MM/yyyy HH:mm", Vi), fontNormal);
        Line($"Nhân viên: {_staff}", fontNormal);
        Line($"Khách hàng: {_customer}", fontNormal);
        if (!string.IsNullOrWhiteSpace(_phone)) Line($"SĐT: {_phone}", fontNormal);
        y += 4;
        Divider();

        // Mỗi mặt hàng: dòng tên, rồi dòng "SL x đơn giá ... thành tiền"
        foreach (var item in _items)
        {
            Line(item.MedicineName, fontBold);
            Row($"   {item.Quantity.ToString("N0", Vi)} x {item.UnitPrice.ToString("N0", Vi)} đ",
                $"{item.LineTotal.ToString("N0", Vi)} đ", fontNormal);
        }

        Divider();
        Row("Tổng tiền hàng:", $"{_total.ToString("N0", Vi)} đ", fontNormal);
        if (_discount > 0) Row("Giảm giá:", $"{_discount.ToString("N0", Vi)} đ", fontNormal);
        if (_pointsUsed > 0) Row("Trừ điểm:", $"{_pointsUsed.ToString("N0", Vi)} đ", fontNormal);
        Row("Thành tiền:", $"{_final.ToString("N0", Vi)} đ", fontBold);
        y += 4;
        Divider();

        var amountDue = _paid ? 0m : _final;
        g.DrawString("SỐ TIỀN CẦN TRẢ:", fontDue, brush, left, y);
        g.DrawString($"{amountDue.ToString("N0", Vi)} đ", fontDue, brush,
            new RectangleF(left, y, width, fontDue.Height), farRight);
        y += fontDue.Height + 4;
        Line(_paid ? "Trạng thái: ĐÃ THANH TOÁN" : "Trạng thái: CHƯA THANH TOÁN", fontBold);
        y += 8;
        g.DrawString("Cảm ơn quý khách!", fontNormal, brush,
            new RectangleF(left, y, width, fontNormal.Height), center);

        e.HasMorePages = false;
    }
}
