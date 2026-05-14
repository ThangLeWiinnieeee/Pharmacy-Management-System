using PharmacyManagementSystem.Entities;

namespace PharmacyManagementSystem.Interfaces.IDAL;

public interface IUserDAL
{
    bool ExistsByUsername(string username);

    User? GetByUsername(string username);

    User Add(User user);
}
