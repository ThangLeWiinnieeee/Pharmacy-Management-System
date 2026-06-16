namespace PharmacyManagementSystem;

partial class InvoiceHistoryForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        invoiceHistoryView = new InvoiceHistoryView();
        SuspendLayout();
        //
        // invoiceHistoryView
        //
        invoiceHistoryView.Dock = DockStyle.Fill;
        invoiceHistoryView.Padding = new Padding(24);
        //
        // InvoiceHistoryForm
        //
        BackColor = Color.FromArgb(248, 249, 250);
        ClientSize = new Size(1180, 760);
        Controls.Add(invoiceHistoryView);
        Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
        MinimumSize = new Size(1060, 680);
        StartPosition = FormStartPosition.CenterParent;
        Text = "Lịch sử bán hàng";
        ResumeLayout(false);
        PerformLayout();
    }

    private InvoiceHistoryView invoiceHistoryView = null!;
}
