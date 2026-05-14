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

        EnsureUserUpdatedAtColumn(context);
        NormalizeUserRoles(context);
    }

    private static void EnsureUserUpdatedAtColumn(AppDbContext context)
    {
        context.Database.ExecuteSqlRaw(
            """
            IF COL_LENGTH('Users', 'UpdatedAt') IS NULL
            BEGIN
                ALTER TABLE Users ADD UpdatedAt datetime2 NULL;
            END
            """);
    }

    private static void NormalizeUserRoles(AppDbContext context)
    {
        context.Database.ExecuteSqlRaw(
            """
            UPDATE Users
            SET Role = 'Staff'
            WHERE Role IS NULL OR UPPER(Role) NOT IN ('ADMIN', 'STAFF');

            UPDATE Users
            SET Role = 'Admin'
            WHERE UPPER(Role) = 'ADMIN';

            UPDATE Users
            SET Role = 'Staff'
            WHERE UPPER(Role) = 'STAFF';
            """);
    }
}
