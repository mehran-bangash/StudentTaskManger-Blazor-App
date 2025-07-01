
using BLL.Interfaces;
using Entities.Models;
using DAL.Interfaces;
namespace BLL.Services
{
    public class CourseBLL : ICourseBLL
    {
        private readonly ICourseDAL _courseDAL;

        // Constructor to inject DAL
        public CourseBLL(ICourseDAL courseDAL)
        {
            _courseDAL = courseDAL;
        }

        public List<Course> GetAllCourses()
        {
            return _courseDAL.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseDAL.GetCourseById(id);
        }

        public void AddCourse(Course course)
        {
            // Add validation if needed
            _courseDAL.AddCourse(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseDAL.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseDAL.DeleteCourse(id);
        }
    }
}