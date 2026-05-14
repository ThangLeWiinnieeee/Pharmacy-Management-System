namespace PharmacyManagementSystem.Interfaces.IView;

public interface IRegisterView
{
    string FullName { get; }

    string Phone { get; }

    string Email { get; }

    string Username { get; }

    string Password { get; }

    string ConfirmPassword { get; }

    void ShowRegisterSuccess(string message);

    void ShowRegisterError(string message);

    void CloseView();
}
