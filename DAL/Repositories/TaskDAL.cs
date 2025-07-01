using DAL.Interfaces;
using Entities.Models;
using Microsoft.Data.SqlClient;
using System.Data;

// ✅ Resolve name conflict with System.Threading.Tasks.Task
using TaskEntity = Entities.Models.Task;

namespace DAL.Repositories
{
    public class TaskDAL : ITaskDAL
    {
        public List<TaskEntity> GetAllTasks()
        {
            List<TaskEntity> tasks = new();

            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Tasks";
            SqlCommand cmd = new(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                tasks.Add(new TaskEntity
                {
                    TaskId = (int)reader["TaskId"],
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    DueDate = reader["DueDate"] == DBNull.Value ? null : (DateTime?)reader["DueDate"],
                    IsCompleted = (bool)reader["IsCompleted"],
                    CourseId = (int)reader["CourseId"],
                    UserId = (int)reader["UserId"]
                });
            }

            return tasks;
        }

        public void AddTask(TaskEntity task)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = @"INSERT INTO Tasks (Title, Description, DueDate, IsCompleted, CourseId, UserId)
                             VALUES (@Title, @Description, @DueDate, @IsCompleted, @CourseId, @UserId)";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Title", task.Title ?? "");
            cmd.Parameters.AddWithValue("@Description", task.Description ?? "");
            cmd.Parameters.AddWithValue("@DueDate", task.DueDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
            cmd.Parameters.AddWithValue("@CourseId", task.CourseId);
            cmd.Parameters.AddWithValue("@UserId", task.UserId);
            cmd.ExecuteNonQuery();
        }

        public void DeleteTask(int id)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = "DELETE FROM Tasks WHERE TaskId = @TaskId";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@TaskId", id);
            cmd.ExecuteNonQuery();
        }

        public void UpdateTask(TaskEntity task)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = @"UPDATE Tasks SET Title=@Title, Description=@Description, DueDate=@DueDate, 
                            IsCompleted=@IsCompleted, CourseId=@CourseId, UserId=@UserId WHERE TaskId=@TaskId";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@Title", task.Title ?? "");
            cmd.Parameters.AddWithValue("@Description", task.Description ?? "");
            cmd.Parameters.AddWithValue("@DueDate", task.DueDate ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@IsCompleted", task.IsCompleted);
            cmd.Parameters.AddWithValue("@CourseId", task.CourseId);
            cmd.Parameters.AddWithValue("@UserId", task.UserId);
            cmd.Parameters.AddWithValue("@TaskId", task.TaskId);
            cmd.ExecuteNonQuery();
        }

        public TaskEntity GetTaskById(int id)
        {
            using SqlConnection conn = DBHelper.DBHelper.GetConnection();
            conn.Open();
            string query = "SELECT * FROM Tasks WHERE TaskId = @TaskId";
            SqlCommand cmd = new(query, conn);
            cmd.Parameters.AddWithValue("@TaskId", id);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new TaskEntity
                {
                    TaskId = (int)reader["TaskId"],
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    DueDate = reader["DueDate"] == DBNull.Value ? null : (DateTime?)reader["DueDate"],
                    IsCompleted = (bool)reader["IsCompleted"],
                    CourseId = (int)reader["CourseId"],
                    UserId = (int)reader["UserId"]
                };
            }

            return null;
        }
    }
}
