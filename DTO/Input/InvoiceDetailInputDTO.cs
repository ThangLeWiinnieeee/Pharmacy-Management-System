namespace PharmacyManagementSystem.DTO.Input;

/// <summary>Một dòng chi tiết trong giỏ hàng khi lập hóa đơn</summary>
public class InvoiceDetailInputDTO
{
    public int MedicineId { get; set; }

    public string MedicineCode { get; set; } = string.Empty;

    public string MedicineName { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal => Quantity * UnitPrice;
}
