namespace PharmacyManagementSystem;

public partial class MedicineForm : Form
{
    public MedicineForm()
    {
        InitializeComponent();
        
        var medicineView = new MedicineManagementView
        {
            Dock = DockStyle.Fill
        };
        
        // Hide add/edit/delete buttons for Staff
        medicineView.EnableReadOnlyMode();

        Controls.Add(medicineView);
    }
}
