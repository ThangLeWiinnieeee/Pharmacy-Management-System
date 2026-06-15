using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IView;

public interface ILoginView
{
    string Username { get; }

    string Password { get; }

    bool RememberMe { get; }

    void ShowLoginError(string message);

    void OpenAdminDashboard(UserDTO user);

    void OpenStaffWorkspace(UserDTO user);
}
