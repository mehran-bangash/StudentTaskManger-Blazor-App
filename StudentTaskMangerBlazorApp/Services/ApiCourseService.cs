using Entities.Models;
using System.Net.Http.Json;

namespace StudentTaskMangerBlazorApp.Services
{
    public class ApiCourseService
    {
        private readonly HttpClient _httpClient;

        public ApiCourseService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("CourseAPI");
        }

        // ✅ Get all courses
        public async System.Threading.Tasks.Task<List<Course>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>("api/course");
        }

        // ✅ Add new course
        public async System.Threading.Tasks.Task AddCourseAsync(Course course)
        {
            var response = await _httpClient.PostAsJsonAsync("api/course", course);
            response.EnsureSuccessStatusCode(); // will throw if failed
        }

        // ✅ Update course
        public async System.Threading.Tasks.Task UpdateCourseAsync(Course course)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/course/{course.CourseId}", course);
            response.EnsureSuccessStatusCode();
        }

        // ✅ Delete course
        public async System.Threading.Tasks.Task DeleteCourseAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/course/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
