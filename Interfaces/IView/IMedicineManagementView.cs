using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IMedicineManagementView
{
    string SearchKeyword { get; }

    string StatusFilter { get; }

    int? SelectedMedicineId { get; }

    void ShowMedicines(IReadOnlyList<MedicineDTO> medicines);

    SaveMedicineDTO? RequestMedicineInput(SaveMedicineDTO? currentMedicine);

    bool Confirm(string message);

    void ShowMessage(string message);

    void ShowError(string message);
}
