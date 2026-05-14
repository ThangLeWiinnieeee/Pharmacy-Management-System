using System.Globalization;
using System.Security.Cryptography;
using PharmacyManagementSystem.BLL.Validations;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class AuthBLL : IAuthBLL
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Pbkdf2Iterations = 100_000;
    private const string StaffRole = "Staff";

    private readonly IUserDAL _userDAL;

    public AuthBLL(IUserDAL userDAL)
    {
        _userDAL = userDAL;
    }

    public LoginResultDTO Login(LoginUserDTO request)
    {
        var username = (request.Username ?? string.Empty).Trim().ToLowerInvariant();
        var password = request.Password ?? string.Empty;

        var validationMessage = AuthValidator.ValidateLogin(username, password);
        if (!string.IsNullOrEmpty(validationMessage))
        {
            return LoginResultDTO.Failure(validationMessage);
        }

        try
        {
            var user = _userDAL.GetByUsername(username);
            if (user is null || !VerifyPassword(password, user.PasswordHash))
            {
                return LoginResultDTO.Failure("Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            if (!user.IsActive)
            {
                return LoginResultDTO.Failure("Tài khoản đã bị khóa.");
            }

            return LoginResultDTO.Success("Đăng nhập thành công.", MapToDTO(user));
        }
        catch
        {
            return LoginResultDTO.Failure("Không thể đăng nhập. Vui lòng kiểm tra kết nối dữ liệu và thử lại.");
        }
    }

    public RegisterResultDTO Register(RegisterUserDTO request)
    {
        var fullName = (request.FullName ?? string.Empty).Trim();
        var phone = (request.Phone ?? string.Empty).Trim();
        var email = (request.Email ?? string.Empty).Trim();
        var username = (request.Username ?? string.Empty).Trim().ToLowerInvariant();
        var password = request.Password ?? string.Empty;
        var confirmPassword = request.ConfirmPassword ?? string.Empty;

        var validationMessage = AuthValidator.ValidateRegister(fullName, phone, email, username, password, confirmPassword);
        if (!string.IsNullOrEmpty(validationMessage))
        {
            return RegisterResultDTO.Failure(validationMessage);
        }

        try
        {
            if (_userDAL.ExistsByUsername(username))
            {
                return RegisterResultDTO.Failure("Tên đăng nhập đã tồn tại.");
            }

            var user = new User
            {
                Username = username,
                PasswordHash = HashPassword(password),
                FullName = fullName,
                Email = email,
                Phone = phone,
                Role = StaffRole,
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            var createdUser = _userDAL.Add(user);

            return RegisterResultDTO.Success(
                "Đăng ký tài khoản thành công.",
                MapToDTO(createdUser));
        }
        catch
        {
            return RegisterResultDTO.Failure("Không thể đăng ký tài khoản. Vui lòng kiểm tra kết nối dữ liệu và thử lại.");
        }
    }

    private static bool VerifyPassword(string password, string passwordHash)
    {
        var parts = passwordHash.Split('$');
        if (parts.Length != 4 || !string.Equals(parts[0], "PBKDF2", StringComparison.Ordinal))
        {
            return false;
        }

        if (!int.TryParse(parts[1], NumberStyles.None, CultureInfo.InvariantCulture, out var iterations))
        {
            return false;
        }

        try
        {
            var salt = Convert.FromBase64String(parts[2]);
            var expectedHash = Convert.FromBase64String(parts[3]);
            var actualHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                HashAlgorithmName.SHA256,
                expectedHash.Length);

            return CryptographicOperations.FixedTimeEquals(actualHash, expectedHash);
        }
        catch (FormatException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }
    }

    private static string HashPassword(string password)
    {
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(
            password,
            salt,
            Pbkdf2Iterations,
            HashAlgorithmName.SHA256,
            KeySize);

        return string.Join(
            '$',
            "PBKDF2",
            Pbkdf2Iterations.ToString(CultureInfo.InvariantCulture),
            Convert.ToBase64String(salt),
            Convert.ToBase64String(hash));
    }

    private static UserDTO MapToDTO(User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            Username = user.Username,
            FullName = user.FullName,
            Email = user.Email,
            Phone = user.Phone,
            Role = user.Role,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}
