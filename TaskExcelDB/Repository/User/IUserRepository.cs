using TaskExcelDB.Models;

namespace TaskExcelDB.Repository.User
{
    public interface IUserRepository
    {
        Users GetUserById(int? id);
        IEnumerable<Users> GetAllUsers();
        void AddUser(Users user);
        void UpdateUser(Users user);
        void DeleteUser(int id);
    }
}
