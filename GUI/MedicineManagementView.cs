using System.Globalization;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Interfaces.IView;
using PharmacyManagementSystem.Presenters;

namespace PharmacyManagementSystem;

public partial class MedicineManagementView : UserControl, IMedicineManagementView
{
    private readonly MedicinePresenter _presenter;

    public MedicineManagementView()
    {
        InitializeComponent();

        _presenter = new MedicinePresenter(this);
        comboStatusFilter.SelectedIndex = 0;

        Load += (_, _) => _presenter.LoadMedicines();
        textSearchMedicine.TextChanged += (_, _) => _presenter.LoadMedicines();
        comboStatusFilter.SelectedIndexChanged += (_, _) => _presenter.LoadMedicines();
        buttonAddMedicine.Click += (_, _) => _presenter.AddMedicine();
        buttonEditMedicine.Click += (_, _) => _presenter.EditMedicine();
        buttonDeleteMedicine.Click += (_, _) => _presenter.DeactivateMedicine();
    }

    public string SearchKeyword => textSearchMedicine.Text.Trim();

    public string StatusFilter => comboStatusFilter.SelectedItem?.ToString() ?? "Tất cả";

    public int? SelectedMedicineId
    {
        get
        {
            if (medicinesGrid.CurrentRow?.Tag is int id)
            {
                return id;
            }

            return null;
        }
    }

    public void ShowMedicines(IReadOnlyList<MedicineDTO> medicines)
    {
        medicinesGrid.Rows.Clear();

        foreach (var medicine in medicines)
        {
            var rowIndex = medicinesGrid.Rows.Add(
                medicine.Code,
                medicine.Name,
                medicine.Unit,
                medicine.Quantity.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")),
                medicine.SellPrice.ToString("N0", CultureInfo.GetCultureInfo("vi-VN")),
                medicine.ExpiryDate?.ToString("dd/MM/yyyy") ?? string.Empty,
                medicine.IsActive ? "Đang kinh doanh" : "Ngừng bán");

            medicinesGrid.Rows[rowIndex].Tag = medicine.Id;
        }
    }

    public SaveMedicineDTO? RequestMedicineInput(SaveMedicineDTO? currentMedicine)
    {
        using var editorForm = new MedicineEditorForm(currentMedicine);
        return editorForm.ShowDialog(this) == DialogResult.OK
            ? editorForm.MedicineInput
            : null;
    }

    public bool Confirm(string message)
    {
        return MessageBox.Show(this, message, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    public void ShowMessage(string message)
    {
        MessageBox.Show(this, message, "Quản lý thuốc", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, "Quản lý thuốc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
}
