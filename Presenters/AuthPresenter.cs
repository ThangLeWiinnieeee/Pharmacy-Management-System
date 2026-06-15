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

    /// <summary>
    /// Thử đăng nhập tự động bằng DPAPI token. Trả về true nếu thành công.
    /// </summary>
    public bool TryAutoLogin()
    {
        if (_loginView is null) return false;
        var rawToken = RememberMeHelper.Load();
        if (rawToken is null) return false;

        var user = _authBLL.LoginWithToken(rawToken);
        if (user is null)
        {
            RememberMeHelper.Clear(); // token hết hạn hoặc bị revoke
            return false;
        }

        NavigateToDashboard(user);
        return true;
    }

    /// <summary>
    /// Revoke remember-me token và xóa file DPAPI (gọi khi logout).
    /// </summary>
    public void Logout()
    {
        var rawToken = RememberMeHelper.Load();
        if (rawToken is not null)
            _authBLL.RevokeRememberToken(rawToken);
        RememberMeHelper.Clear();
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

        // Ghi nhớ đăng nhập nếu user chọn
        if (_loginView.RememberMe)
        {
            try
            {
                var rawToken = _authBLL.CreateRememberToken(result.User.Id);
                RememberMeHelper.Save(rawToken);
            }
            catch { /* không block login nếu lưu token thất bại */ }
        }

        NavigateToDashboard(result.User);
    }

    private void NavigateToDashboard(PharmacyManagementSystem.DTO.Output.UserDTO user)
    {
        if (_loginView is null) return;

        if (string.Equals(user.Role, AdminRole, StringComparison.OrdinalIgnoreCase))
        {
            _loginView.OpenAdminDashboard(user);
            return;
        }

        if (string.Equals(user.Role, StaffRole, StringComparison.OrdinalIgnoreCase))
        {
            _loginView.OpenStaffWorkspace(user);
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
