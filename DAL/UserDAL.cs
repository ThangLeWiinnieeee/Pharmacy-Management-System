using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.Interfaces.IDAL;

namespace PharmacyManagementSystem.DAL;

public class UserDAL : IUserDAL
{
    public bool ExistsByUsername(string username)
    {
        using var context = new AppDbContext();
        return context.Users.Any(user => user.Username == username);
    }

    public User? GetByUsername(string username)
    {
        using var context = new AppDbContext();
        return context.Users.FirstOrDefault(user => user.Username == username);
    }

    public User Add(User user)
    {
        using var context = new AppDbContext();

        context.Users.Add(user);
        context.SaveChanges();

        return user;
    }
}
