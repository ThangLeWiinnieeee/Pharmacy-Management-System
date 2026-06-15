using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using PharmacyManagementSystem.Entities;

namespace PharmacyManagementSystem.DAL;

public class RememberMeTokenDAL
{
    private const int ExpiryDays = 30;

    /// <summary>
    /// Tạo token mới cho user. Xóa token cũ (1 session/device). Trả về token thô (Base64).
    /// </summary>
    public string Create(int userId)
    {
        var rawBytes = RandomNumberGenerator.GetBytes(32);
        var rawToken = Convert.ToBase64String(rawBytes);
        var hash = ComputeHash(rawBytes);

        using var db = new AppDbContext();
        // Chỉ giữ 1 token active mỗi user
        db.RememberMeTokens.RemoveRange(db.RememberMeTokens.Where(t => t.UserId == userId));
        db.RememberMeTokens.Add(new RememberMeToken
        {
            UserId    = userId,
            TokenHash = hash,
            ExpiresAt = DateTime.UtcNow.AddDays(ExpiryDays),
            CreatedAt = DateTime.UtcNow
        });
        db.SaveChanges();
        return rawToken;
    }

    /// <summary>
    /// Xác thực token và gia hạn sliding expiry. Trả về User entity nếu hợp lệ.
    /// </summary>
    public User? ValidateAndRenew(string rawToken)
    {
        byte[] rawBytes;
        try { rawBytes = Convert.FromBase64String(rawToken); }
        catch { return null; }

        var hash = ComputeHash(rawBytes);
        var now  = DateTime.UtcNow;

        using var db = new AppDbContext();
        var record = db.RememberMeTokens
            .Include(t => t.User)
            .FirstOrDefault(t => t.TokenHash == hash && t.ExpiresAt > now);

        if (record is null || !record.User.IsActive) return null;

        record.ExpiresAt = now.AddDays(ExpiryDays); // sliding window
        db.SaveChanges();
        return record.User;
    }

    /// <summary>
    /// Xóa token khỏi DB (gọi khi logout).
    /// </summary>
    public void Revoke(string rawToken)
    {
        byte[] rawBytes;
        try { rawBytes = Convert.FromBase64String(rawToken); }
        catch { return; }

        var hash = ComputeHash(rawBytes);
        using var db = new AppDbContext();
        var record = db.RememberMeTokens.FirstOrDefault(t => t.TokenHash == hash);
        if (record is null) return;
        db.RememberMeTokens.Remove(record);
        db.SaveChanges();
    }

    private static string ComputeHash(byte[] rawBytes)
    {
        var hash = SHA256.HashData(rawBytes);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}
