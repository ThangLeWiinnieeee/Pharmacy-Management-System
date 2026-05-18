using System.Net.Mail;
using System.Text.RegularExpressions;
using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem.BLL.Validations;

public static class EmployeeValidator
{
    private const int MinUsernameLength = 3;
    private const int MaxUsernameLength = 50;
    private const int MinPasswordLength = 6;
    private const int MaxPasswordLength = 100;

    private static readonly Regex UsernameRegex = new(
        @"^[a-zA-Z0-9._-]+$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private static readonly Regex PhoneRegex = new(
        @"^[0-9+\-\s().]{8,20}$",
        RegexOptions.Compiled | RegexOptions.CultureInvariant);

    public static string? Validate(SaveEmployeeDTO request)
    {
        var isCreate = !request.Id.HasValue;

        if (string.IsNullOrWhiteSpace(request.FullName))
        {
            return "Vui lòng nhập họ tên.";
        }

        if (request.FullName.Trim().Length > 100)
        {
            return "Họ tên không được vượt quá 100 ký tự.";
        }

        if (string.IsNullOrWhiteSpace(request.Username))
        {
            return "Vui lòng nhập tên đăng nhập.";
        }

        var username = request.Username.Trim();
        if (username.Length < MinUsernameLength || username.Length > MaxUsernameLength)
        {
            return "Tên đăng nhập phải từ 3 đến 50 ký tự.";
        }

        if (!UsernameRegex.IsMatch(username))
        {
            return "Tên đăng nhập chỉ được chứa chữ, số, dấu chấm, gạch dưới hoặc gạch ngang.";
        }

        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return "Vui lòng nhập email.";
        }

        if (!IsValidEmail(request.Email.Trim()))
        {
            return "Email không hợp lệ.";
        }

        if (string.IsNullOrWhiteSpace(request.Phone))
        {
            return "Vui lòng nhập số điện thoại.";
        }

        if (!PhoneRegex.IsMatch(request.Phone.Trim()))
        {
            return "Số điện thoại không hợp lệ.";
        }

        if (request.Role is not "Admin" and not "Staff")
        {
            return "Vai trò chỉ được là Admin hoặc Staff.";
        }

        if (isCreate && string.IsNullOrWhiteSpace(request.Password))
        {
            return "Vui lòng nhập mật khẩu cho nhân viên mới.";
        }

        if (!string.IsNullOrWhiteSpace(request.Password)
            && (request.Password.Length < MinPasswordLength || request.Password.Length > MaxPasswordLength))
        {
            return "Mật khẩu phải từ 6 đến 100 ký tự.";
        }

        return null;
    }

    private static bool IsValidEmail(string email)
    {
        try
        {
            var mailAddress = new MailAddress(email);
            return string.Equals(mailAddress.Address, email, StringComparison.OrdinalIgnoreCase);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
