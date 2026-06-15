using System.Security.Cryptography;
using System.Text;

namespace PharmacyManagementSystem.BLL;

/// <summary>
/// Lưu/đọc/xóa remember-me token bằng Windows DPAPI (CurrentUser scope).
/// File chỉ giải mã được bởi đúng Windows account trên đúng máy này.
/// </summary>
internal static class RememberMeHelper
{
    private static readonly string FilePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "PharmacyMS",
        "session.dat");

    public static void Save(string rawToken)
    {
        var dir = Path.GetDirectoryName(FilePath)!;
        Directory.CreateDirectory(dir);
        var plainBytes = Encoding.UTF8.GetBytes(rawToken);
        var encrypted  = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
        File.WriteAllBytes(FilePath, encrypted);
    }

    public static string? Load()
    {
        if (!File.Exists(FilePath)) return null;
        try
        {
            var encrypted  = File.ReadAllBytes(FilePath);
            var plainBytes = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(plainBytes);
        }
        catch
        {
            Clear(); // dữ liệu hỏng hoặc sai user/máy → xóa
            return null;
        }
    }

    public static void Clear()
    {
        try
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);
        }
        catch { /* ignore */ }
    }
}
