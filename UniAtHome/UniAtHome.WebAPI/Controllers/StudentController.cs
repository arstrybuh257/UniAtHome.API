using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs.Students;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Models.Responses;
using UniAtHome.WebAPI.Models.Responses.Course;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController, Authorize]
    [ApiController]
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
        public async Task<ObjectResult> GetCoursesForStudent(string email)
        {
            var coursesRequest = new StudentsCoursesRequest { StudentEmail = email };
            GetCoursesResponse response = new GetCoursesResponse
            {
                Courses = mapper.Map<IEnumerable<CourseResponseModel>>(await studentsService.GetStudentsCoursesAsync(coursesRequest))
            };
            return Ok(response);
        }

        [HttpGet("courses")]
        public async Task<ObjectResult> GetCoursesForUser()
        {
            var coursesRequest = new StudentsCoursesRequest { StudentEmail = User.Identity.Name };
            GetCoursesResponse response = new GetCoursesResponse
            {
                Courses = mapper.Map<IEnumerable<CourseResponseModel>>(await studentsService.GetStudentsCoursesAsync(coursesRequest))
            };
            return Ok(response);
        }
    }
}
