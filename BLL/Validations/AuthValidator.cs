using System.Net.Mail;
using System.Text.RegularExpressions;

namespace PharmacyManagementSystem.BLL.Validations;

public static class AuthValidator
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

    public static string? ValidateLogin(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username))
        {
            return "Vui lòng nhập tên đăng nhập.";
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            return "Vui lòng nhập mật khẩu.";
        }

        return null;
    }

    public static string? ValidateRegister(
        string fullName,
        string? phone,
        string? email,
        string username,
        string password,
        string confirmPassword)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            return "Vui lòng nhập họ tên.";
        }

        if (fullName.Length > 100)
        {
            return "Họ tên không được vượt quá 100 ký tự.";
        }

        if (string.IsNullOrWhiteSpace(username))
        {
            return "Vui lòng nhập tên đăng nhập.";
        }

        if (username.Length < MinUsernameLength || username.Length > MaxUsernameLength)
        {
            return "Tên đăng nhập phải từ 3 đến 50 ký tự.";
        }

        if (!UsernameRegex.IsMatch(username))
        {
            return "Tên đăng nhập chỉ được chứa chữ, số, dấu chấm, gạch dưới hoặc gạch ngang.";
        }

        if (!string.IsNullOrWhiteSpace(email) && !IsValidEmail(email))
        {
            return "Email không hợp lệ.";
        }

        if (!string.IsNullOrWhiteSpace(phone) && !PhoneRegex.IsMatch(phone))
        {
            return "Số điện thoại không hợp lệ.";
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            return "Vui lòng nhập mật khẩu.";
        }

        if (password.Length < MinPasswordLength || password.Length > MaxPasswordLength)
        {
            return "Mật khẩu phải từ 6 đến 100 ký tự.";
        }

        if (password != confirmPassword)
        {
            return "Mật khẩu nhập lại không khớp.";
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
