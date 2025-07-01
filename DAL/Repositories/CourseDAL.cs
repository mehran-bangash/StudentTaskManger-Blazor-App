using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Entities.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class CourseDAL : ICourseDAL
    {
        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection conn = DBHelper.DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Courses";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Course c = new Course
                    {
                        CourseId = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString(),
                        CourseCode = reader["CourseCode"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                    courses.Add(c);
                }
            }

            return courses;
        }

        public void AddCourse(Course course)
        {
            using (SqlConnection conn = DBHelper.DBHelper.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Courses (CourseName, CourseCode, Description)
                 VALUES (@CourseName, @CourseCode, @Description)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteCourse(int id)
        {
            using (SqlConnection conn = DBHelper.DBHelper.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Courses WHERE CourseId = @CourseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CourseId", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateCourse(Course course)
        {
            using (SqlConnection conn = DBHelper.DBHelper.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Courses SET CourseName = @CourseName, CourseCode = @CourseCode, Description = @Description WHERE CourseId = @CourseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CourseName", course.CourseName);
                cmd.Parameters.AddWithValue("@CourseCode", course.CourseCode);
                cmd.Parameters.AddWithValue("@Description", course.Description);
                cmd.Parameters.AddWithValue("@CourseId", course.CourseId);
                cmd.ExecuteNonQuery();
            }
        }

        public Course GetCourseById(int id)
        {
            Course course = null;

            using (SqlConnection conn = DBHelper.DBHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Courses WHERE CourseId = @CourseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CourseId", id);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course
                    {
                        CourseId = (int)reader["CourseId"],
                        CourseName = reader["CourseName"].ToString(),
                        CourseCode = reader["CourseCode"].ToString(),
                        Description = reader["Description"].ToString()
                    };
                }
            }

            return course;
        }
    }
}
