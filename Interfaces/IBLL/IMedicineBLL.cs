using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface IMedicineBLL
{
    IReadOnlyList<MedicineDTO> GetMedicines(MedicineQueryDTO query);

    SaveMedicineDTO? GetMedicineForEdit(int id);

    OperationResultDTO SaveMedicine(SaveMedicineDTO request);

    OperationResultDTO DeactivateMedicine(int id);
}
