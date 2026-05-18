using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface IEmployeeManagementView
{
    string SearchKeyword { get; }

    string StatusFilter { get; }

    string RoleFilter { get; }

    int? SelectedEmployeeId { get; }

    void ShowEmployees(IReadOnlyList<UserDTO> employees);

    SaveEmployeeDTO? RequestEmployeeInput(SaveEmployeeDTO? currentEmployee);

    bool Confirm(string message);

    void ShowMessage(string message);

    void ShowError(string message);
}
