using BLL.Interfaces;
using DAL.Interfaces;
using Entities.Models;
using System.Collections.Generic;

namespace BLL.Services
{
    public class UserBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;

        public UserBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public List<User> GetAllUsers()
        {
            return _userDAL.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return _userDAL.GetUserById(id);
        }

        public void AddUser(User user)
        {
            _userDAL.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            _userDAL.UpdateUser(user);
        }

        public void DeleteUser(int id)
        {
            _userDAL.DeleteUser(id);
        }
    }
}
