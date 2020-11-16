using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Teacher;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Models.Filters;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        private readonly IMapper mapper;

        public TeacherController(ITeacherService teacherService, IMapper mapper)
        {
            this.teacherService = teacherService;
            this.mapper = mapper;
        }

        [HttpGet("courses/{email}")]
        [Authorize(Roles = RoleName.ADMIN)]
        public async Task<ObjectResult> GetCoursesForTeacherAsync(string email)
        {
            var coursesRequest = new CoursesFilter { UserEmail = email };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await teacherService.GetTeahersCoursesAsync(coursesRequest));
            return Ok(coursesResponse);
        }

        [HttpGet("courses")]
        [Authorize(Roles=RoleName.TEACHER)]
        public async Task<ObjectResult> GetCoursesForUserAsync(FindCoursesRequest request)
        {
            var filter = mapper.Map<CoursesFilter>(request);
            filter.UserEmail = User.Identity.Name;
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await teacherService.GetTeahersCoursesAsync(filter));
            return Ok(coursesResponse);
        }
    }
}