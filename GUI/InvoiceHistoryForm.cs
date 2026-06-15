using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem;

public class InvoiceHistoryForm : Form
{
    public InvoiceHistoryForm(UserDTO currentUser)
    {
        Text = "Lịch sử bán hàng";
        StartPosition = FormStartPosition.CenterParent;
        MinimumSize = new Size(1060, 680);
        Size = new Size(1180, 760);
        BackColor = Color.FromArgb(248, 249, 250);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

        var view = new InvoiceHistoryView
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(24)
        };

        Controls.Add(view);
    }
}
