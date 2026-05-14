using Microsoft.EntityFrameworkCore;

namespace PharmacyManagementSystem.DAL;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        using var context = new AppDbContext();

        if (!context.Database.CanConnect())
        {
            throw new InvalidOperationException("Khong the ket noi database PharmacyManagementSystemDb.");
        }
    }
}
