using Entities.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserBLL
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
