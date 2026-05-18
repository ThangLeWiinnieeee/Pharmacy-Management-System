using PharmacyManagementSystem.Entities;
using PharmacyManagementSystem.DTO.Input;

namespace PharmacyManagementSystem.Interfaces.IDAL;

public interface IUserDAL
{
    List<User> GetUsers(EmployeeQueryDTO query);

    User? GetById(int id);

    bool ExistsByUsername(string username);

    bool ExistsByUsername(string username, int? excludedId);

    User? GetByUsername(string username);

    User Add(User user);

    void Update(User user);

    void SetActive(int id, bool isActive);
}
