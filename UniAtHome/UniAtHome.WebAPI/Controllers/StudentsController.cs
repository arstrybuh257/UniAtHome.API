using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs.Students;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class StudentsController : ControllerBase
    {
        private IStudentsService studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet("courses/{email}")]
        public async Task<ObjectResult> GetCoursesForStudent(string email)
        {
            StudentsCoursesRequest request = new StudentsCoursesRequest { StudentEmail = email };
            StudentsCoursesResponse response = await studentsService.GetStudentsCoursesAsync(request);
            return Ok(response.CoursesIds);
        }

        [HttpGet("courses")]
        public async Task<ObjectResult> GetCoursesForUser()
        {
            StudentsCoursesRequest request = new StudentsCoursesRequest { StudentEmail = User.Identity.Name };
            StudentsCoursesResponse response = await studentsService.GetStudentsCoursesAsync(request);
            return Ok(response.CoursesIds);
        }
    }
}
