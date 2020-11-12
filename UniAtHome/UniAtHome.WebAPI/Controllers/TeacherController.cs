using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Teacher;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;
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
            var coursesRequest = new TeachersCoursesRequest { TeacherEmail = email };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await teacherService.GetTeahersCoursesAsync(coursesRequest));
            return Ok(coursesResponse);
        }

        [HttpGet("courses")]
        [Authorize(Roles=RoleName.TEACHER)]
        public async Task<ObjectResult> GetCoursesForUserAsync()
        {
            var coursesRequest = new TeachersCoursesRequest { TeacherEmail = User.Identity.Name };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await teacherService.GetTeahersCoursesAsync(coursesRequest));
            return Ok(coursesResponse);
        }
    }
}