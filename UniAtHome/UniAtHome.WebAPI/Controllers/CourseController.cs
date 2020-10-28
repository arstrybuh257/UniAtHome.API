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
        public IEnumerable<string> GetAllUserCourses()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Course/5
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

        // POST: api/Course
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseDTO course)
        {
            if (course != null && ModelState.IsValid)
            {
                await this.courseService.AddCourseAsync(course);
                return Ok();
            }

            return BadRequest();
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