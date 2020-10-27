using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService courseService;

        public CourseController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet]
        public IEnumerable<string> GetAllCourses()
        {
            return new string[] { "value1", "value2" };
        }

        // DELETE: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await this.courseService.GetCourseByIdAsync(id);
            if (course != null)
            {
                return Ok(course);
            }

            return BadRequest();
        }

        [HttpPost]
        public void CreateCourse([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void UpdateCourse(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}