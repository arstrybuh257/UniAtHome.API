using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;
using UniAtHome.WebAPI.Models.Responses.Lesson;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        private readonly IMapper mapper;

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

        // GET: api/Course/5
        [HttpGet("{id}/Lessons")]
        public async Task<IActionResult> GetCourseWithLessonsById(int id)
        {
            var course = await courseService.GetCourseWithLessonsByIdAsync(id);
            if (course != null)
            {
                CourseWithLessonsResponse response = new CourseWithLessonsResponse
                {
                    Course = mapper.Map<CourseResponse>(course),
                    ListLessons = mapper.Map<IEnumerable<LessonResponse>>(course.Lessons)
                };

                return Ok(response);
            }

            return BadRequest();
        }

        // POST: api/Course
        [HttpPost]
        [Authorize(Roles = RoleName.TEACHER)]
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

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleName.TEACHER)]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            //temporary
            if (await courseService.DeleteCourseAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}