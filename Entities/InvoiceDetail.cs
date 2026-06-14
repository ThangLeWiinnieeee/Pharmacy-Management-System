namespace PharmacyManagementSystem.Entities;

public class InvoiceDetail
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public int MedicineId { get; set; }

    /// <summary>Snapshot mã thuốc tại thời điểm lập hóa đơn</summary>
    public string MedicineCode { get; set; } = string.Empty;

    /// <summary>Snapshot tên thuốc tại thời điểm lập hóa đơn</summary>
    public string MedicineName { get; set; } = string.Empty;

    public string Unit { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }

    // Navigation
    public Invoice? Invoice { get; set; }

    public Medicine? Medicine { get; set; }
}
