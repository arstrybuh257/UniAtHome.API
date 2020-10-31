using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Extensions;
using UniAtHome.WebAPI.Models.Requests;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService courseService;
        private IMapper mapper;

        public CourseController(ICourseService courseService, IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await courseService.GetCourseByIdAsync(id);
            if (course != null)
            {
                return Ok(course);
            }

            return BadRequest();
        }

        // POST: api/Course
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            if (request != null && ModelState.IsValid)
            {
                var courseDto = mapper.Map<CreateCourseRequest, CourseDTO>(request);
                courseDto.TeacherEmail = User.Identity.Name;
                await courseService.AddCourseAsync(courseDto);
                return Ok();
            }

            return BadRequest();
        }
    }
}