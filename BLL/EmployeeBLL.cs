using System.Globalization;
using System.Security.Cryptography;
using PharmacyManagementSystem.BLL.Validations;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.DTO.Output;
using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IBLL;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.BLL;

public class EmployeeBLL : IEmployeeBLL
{
    private const int SaltSize = 16;
    private const int KeySize = 32;
    private const int Pbkdf2Iterations = 100_000;

    private readonly IUserDAL _userDAL;

    public EmployeeBLL(IUserDAL userDAL)
    {
        _userDAL = userDAL;
    }

    public IReadOnlyList<UserDTO> GetEmployees(EmployeeQueryDTO query)
    {
        return _userDAL.GetUsers(query).Select(MapToDTO).ToList();
    }

    public SaveEmployeeDTO? GetEmployeeForEdit(int id)
    {
        var user = _userDAL.GetById(id);
        return user is null ? null : MapToInputDTO(user);
    }

    public OperationResultDTO SaveEmployee(SaveEmployeeDTO request)
    {
        Normalize(request);

        var validationMessage = EmployeeValidator.Validate(request);
        if (!string.IsNullOrEmpty(validationMessage))
        {
            return OperationResultDTO.Failure(validationMessage);
        }

        if (_userDAL.ExistsByUsername(request.Username, request.Id))
        {
            return OperationResultDTO.Failure("Tên đăng nhập đã tồn tại.");
        }

        try
        {
            if (request.Id.HasValue)
            {
                return UpdateEmployee(request);
            }

            return CreateEmployee(request);
        }
        catch
        {
            return OperationResultDTO.Failure("Không thể lưu thông tin nhân viên. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    public OperationResultDTO ToggleEmployeeActive(int id)
    {
        try
        {
            var user = _userDAL.GetById(id);
            if (user is null)
            {
                return OperationResultDTO.Failure("Không tìm thấy nhân viên cần cập nhật.");
            }

            var nextState = !user.IsActive;
            _userDAL.SetActive(id, nextState);

            return OperationResultDTO.Success(nextState
                ? "Đã mở khóa tài khoản nhân viên."
                : "Đã khóa tài khoản nhân viên.");
        }
        catch
        {
            return OperationResultDTO.Failure("Không thể cập nhật trạng thái nhân viên. Vui lòng kiểm tra kết nối dữ liệu.");
        }
    }

    private OperationResultDTO CreateEmployee(SaveEmployeeDTO request)
    {
        var user = new User
        {
            Username = request.Username,
            PasswordHash = HashPassword(request.Password),
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone,
            Role = request.Role,
            IsActive = request.IsActive,
            CreatedAt = DateTime.Now
        };

        _userDAL.Add(user);
        return OperationResultDTO.Success("Đã thêm nhân viên mới.");
    }

    private OperationResultDTO UpdateEmployee(SaveEmployeeDTO request)
    {
        var existingUser = _userDAL.GetById(request.Id!.Value);
        if (existingUser is null)
        {
            return OperationResultDTO.Failure("Không tìm thấy nhân viên cần cập nhật.");
        }

        existingUser.Username = request.Username;
        existingUser.FullName = request.FullName;
        existingUser.Email = request.Email;
        existingUser.Phone = request.Phone;
        existingUser.Role = request.Role;
        existingUser.IsActive = request.IsActive;
        existingUser.UpdatedAt = DateTime.Now;

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            existingUser.PasswordHash = HashPassword(request.Password);
        }

        _userDAL.Update(existingUser);
        return OperationResultDTO.Success("Đã cập nhật thông tin nhân viên.");
    }

    private static void Normalize(SaveEmployeeDTO request)
    {
        request.Username = request.Username.Trim().ToLowerInvariant();
        request.FullName = request.FullName.Trim();
        request.Email = request.Email.Trim();
        request.Phone = request.Phone.Trim();
        request.Role = request.Role.Trim();
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

    private static SaveEmployeeDTO MapToInputDTO(User user)
    {
        return new SaveEmployeeDTO
        {
            Id = user.Id,
            Username = user.Username,
            FullName = user.FullName,
            Email = user.Email,
            Phone = user.Phone,
            Role = user.Role,
            IsActive = user.IsActive
        };
    }
}
