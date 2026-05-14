using PharmacyManagementSystem.BLL;
using PharmacyManagementSystem.DAL;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IView;

namespace PharmacyManagementSystem.Presenters;

public class AuthPresenter
{
    private const string AdminRole = "Admin";
    private const string StaffRole = "Staff";

    private readonly IAuthBLL _authBLL;
    private readonly ILoginView? _loginView;
    private readonly IRegisterView? _registerView;

    public AuthPresenter(IRegisterView registerView)
        : this(null, registerView, new AuthBLL(new UserDAL()))
    {
    }

    public AuthPresenter(ILoginView loginView)
        : this(loginView, null, new AuthBLL(new UserDAL()))
    {
    }

    public AuthPresenter(IRegisterView registerView, IAuthBLL authBLL)
        : this(null, registerView, authBLL)
    {
    }

    public AuthPresenter(ILoginView loginView, IAuthBLL authBLL)
        : this(loginView, null, authBLL)
    {
    }

    private AuthPresenter(ILoginView? loginView, IRegisterView? registerView, IAuthBLL authBLL)
    {
        _loginView = loginView;
        _registerView = registerView;
        _authBLL = authBLL;
    }

    public void Login()
    {
        if (_loginView is null)
        {
            throw new InvalidOperationException("Login view is not configured.");
        }

        var request = new LoginUserDTO
        {
            Username = _loginView.Username,
            Password = _loginView.Password
        };

        var result = _authBLL.Login(request);
        if (!result.IsSuccess || result.User is null)
        {
            _loginView.ShowLoginError(result.Message);
            return;
        }

        if (string.Equals(result.User.Role, AdminRole, StringComparison.OrdinalIgnoreCase))
        {
            _loginView.OpenAdminDashboard(result.User);
            return;
        }

        if (string.Equals(result.User.Role, StaffRole, StringComparison.OrdinalIgnoreCase))
        {
            _loginView.OpenStaffWorkspace(result.User);
            return;
        }

        _loginView.ShowLoginError("Vai trò tài khoản không hợp lệ.");
    }

    public void Register()
    {
        if (_registerView is null)
        {
            throw new InvalidOperationException("Register view is not configured.");
        }

        var request = new RegisterUserDTO
        {
            FullName = _registerView.FullName,
            Phone = _registerView.Phone,
            Email = _registerView.Email,
            Username = _registerView.Username,
            Password = _registerView.Password,
            ConfirmPassword = _registerView.ConfirmPassword
        };

        var result = _authBLL.Register(request);
        if (!result.IsSuccess)
        {
            _registerView.ShowRegisterError(result.Message);
            return;
        }

        _registerView.ShowRegisterSuccess(result.Message);
        _registerView.CloseView();
    }
}
