using DAL.Interfaces;
using Entities.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public class UserDAL : IUserDAL
    {
        public List<User> GetAllUsers()
        {
            List<User> users = new();
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Users";
            SqlCommand cmd = new(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                users.Add(new User
                {
                    UserId = (int)reader["UserId"],
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    GoogleId = reader["GoogleId"].ToString(),
                    DateRegistered = (DateTime)reader["DateRegistered"]
                });
            }

            return users;
        }

        public User GetUserById(int id)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Users WHERE UserId = @UserId";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@UserId", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new User
                {
                    UserId = (int)reader["UserId"],
                    FullName = reader["FullName"].ToString(),
                    Email = reader["Email"].ToString(),
                    GoogleId = reader["GoogleId"].ToString(),
                    DateRegistered = (DateTime)reader["DateRegistered"]
                };
            }

            return null;
        }

        public void AddUser(User user)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = @"INSERT INTO Users (FullName, Email, GoogleId, DateRegistered)
                             VALUES (@FullName, @Email, @GoogleId, @DateRegistered)";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@FullName", user.FullName ?? "");
            cmd.Parameters.AddWithValue("@Email", user.Email ?? "");
            cmd.Parameters.AddWithValue("@GoogleId", user.GoogleId ?? "");
            cmd.Parameters.AddWithValue("@DateRegistered", user.DateRegistered);
            cmd.ExecuteNonQuery();
        }

        public void UpdateUser(User user)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = @"UPDATE Users SET FullName=@FullName, Email=@Email, GoogleId=@GoogleId 
                             WHERE UserId=@UserId";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@FullName", user.FullName ?? "");
            cmd.Parameters.AddWithValue("@Email", user.Email ?? "");
            cmd.Parameters.AddWithValue("@GoogleId", user.GoogleId ?? "");
            cmd.Parameters.AddWithValue("@UserId", user.UserId);
            cmd.ExecuteNonQuery();
        }

        public void DeleteUser(int id)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = "DELETE FROM Users WHERE UserId = @UserId";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@UserId", id);
            cmd.ExecuteNonQuery();
        }
    }
}
