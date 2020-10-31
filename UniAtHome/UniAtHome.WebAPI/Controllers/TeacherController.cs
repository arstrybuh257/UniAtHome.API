using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs.Teacher;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpGet("courses/{email}")]
        public async Task<ObjectResult> GetCoursesForTeacher(string email)
        {
            var coursesRequest = new TeachersCoursesRequest { TeacherEmail = email };
            return Ok(await this.teacherService.GetTeahersCoursesAsync(coursesRequest));
        }

        [HttpGet("courses")]
        public async Task<ObjectResult> GetCoursesForUser()
        {
            var coursesRequest = new TeachersCoursesRequest { TeacherEmail = User.Identity.Name };
            return Ok(await this.teacherService.GetTeahersCoursesAsync(coursesRequest));
        }
    }
}