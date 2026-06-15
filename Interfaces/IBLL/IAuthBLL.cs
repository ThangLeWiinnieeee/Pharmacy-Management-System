using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;

namespace PharmacyManagementSystem.Interfaces.IBLL;

public interface IAuthBLL
{
    LoginResultDTO Login(LoginUserDTO request);

    RegisterResultDTO Register(RegisterUserDTO request);

    UserDTO? LoginWithToken(string rawToken);

    string CreateRememberToken(int userId);

    void RevokeRememberToken(string rawToken);
}
