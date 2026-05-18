using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.DTO.Input;
using PharmacyManagementSystem.Interfaces.IDAL;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagementSystem.DAL;

public class UserDAL : IUserDAL
{
    public List<User> GetUsers(EmployeeQueryDTO query)
    {
        using var context = new AppDbContext();

        var users = context.Users.AsNoTracking().AsQueryable();
        var keyword = (query.Keyword ?? string.Empty).Trim();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            users = users.Where(user =>
                user.Username.Contains(keyword)
                || user.FullName.Contains(keyword)
                || user.Email.Contains(keyword)
                || user.Phone.Contains(keyword));
        }

        users = query.StatusFilter switch
        {
            "Đang hoạt động" => users.Where(user => user.IsActive),
            "Đã khóa" => users.Where(user => !user.IsActive),
            _ => users
        };

        if (query.RoleFilter is "Admin" or "Staff")
        {
            users = users.Where(user => user.Role == query.RoleFilter);
        }

        return users
            .OrderByDescending(user => user.IsActive)
            .ThenBy(user => user.FullName)
            .ToList();
    }

    public User? GetById(int id)
    {
        using var context = new AppDbContext();
        return context.Users.AsNoTracking().FirstOrDefault(user => user.Id == id);
    }

    public bool ExistsByUsername(string username)
    {
        using var context = new AppDbContext();
        return context.Users.Any(user => user.Username == username);
    }

    public bool ExistsByUsername(string username, int? excludedId)
    {
        using var context = new AppDbContext();
        return context.Users.Any(user =>
            user.Username == username
            && (!excludedId.HasValue || user.Id != excludedId.Value));
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

    public void Update(User user)
    {
        using var context = new AppDbContext();

        context.Users.Update(user);
        context.SaveChanges();
    }

    public void SetActive(int id, bool isActive)
    {
        using var context = new AppDbContext();
        var user = context.Users.FirstOrDefault(item => item.Id == id);

        if (user is null)
        {
            return;
        }

        user.IsActive = isActive;
        user.UpdatedAt = DateTime.Now;
        context.SaveChanges();
    }
}
