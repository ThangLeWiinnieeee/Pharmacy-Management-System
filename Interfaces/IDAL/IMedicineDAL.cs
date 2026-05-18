using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.Entities;

namespace PharmacyManagementSystem.Interfaces.IDAL;

public interface IMedicineDAL
{
    List<Medicine> GetMedicines(MedicineQueryDTO query);

    Medicine? GetById(int id);

    bool ExistsByCode(string code, int? excludedId = null);

    Medicine Add(Medicine medicine);

    void Update(Medicine medicine);

    void SetActive(int id, bool isActive);
}
