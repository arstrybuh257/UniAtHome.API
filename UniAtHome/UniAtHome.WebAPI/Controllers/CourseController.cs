using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetAllCourses()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}", Name = "GetCourseById")]
        public string GetCourseById(int id)
        {
            return "value";
        }

        [HttpPost]
        public void CreateCourse([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void UpdateCourse(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}