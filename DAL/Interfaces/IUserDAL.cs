using Entities.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }
}
