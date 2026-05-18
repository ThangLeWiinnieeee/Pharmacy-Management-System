using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface IEmployeeBLL
{
    IReadOnlyList<UserDTO> GetEmployees(EmployeeQueryDTO query);

    SaveEmployeeDTO? GetEmployeeForEdit(int id);

    OperationResultDTO SaveEmployee(SaveEmployeeDTO request);

    OperationResultDTO ToggleEmployeeActive(int id);
}
