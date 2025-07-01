using BLL.Interfaces;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace StudentTaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseBLL _courseBLL;

        public CourseController(ICourseBLL courseBLL)
        {
            _courseBLL = courseBLL;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            return Ok(_courseBLL.GetAllCourses());
        }

        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            var course = _courseBLL.GetCourseById(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Course course)
        {
            _courseBLL.AddCourse(course);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Course course)
        {
            if (id != course.CourseId)
                return BadRequest("ID mismatch between URL and body.");

            _courseBLL.UpdateCourse(course);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseBLL.DeleteCourse(id);
            return Ok();
        }
    }
}
