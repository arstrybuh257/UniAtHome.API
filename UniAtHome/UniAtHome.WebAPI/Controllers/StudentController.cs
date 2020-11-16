using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs.Students;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Models.Filters;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService studentsService;

        private readonly IMapper mapper;

        public StudentsController(IStudentService studentsService, IMapper mapper)
        {
            this.studentsService = studentsService;
            this.mapper = mapper;
        }

        [HttpGet("courses/{email}")]
        [Authorize(Roles = RoleName.ADMIN)]
        public async Task<ObjectResult> GetCoursesForStudent(string email)
        {
            var coursesRequest = new CoursesFilter { UserEmail = email };
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await studentsService.GetStudentsCoursesAsync(coursesRequest));
            return Ok(coursesResponse);
        }

        [HttpGet("courses")]
        [Authorize(Roles = RoleName.STUDENT)]
        public async Task<ObjectResult> GetCoursesForUserAsync(FindCoursesRequest request)
        {
            var filter = mapper.Map<CoursesFilter>(request);
            filter.UserEmail = User.Identity.Name;
            var coursesResponse = mapper.Map<IEnumerable<CourseResponse>>(await studentsService.GetStudentsCoursesAsync(filter));
            return Ok(coursesResponse);
        }
    }
}
