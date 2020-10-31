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
        private IStudentService studentsService;

        public StudentsController(IStudentService studentsService)
        {
            this.studentsService = studentsService;
        }

        [HttpGet("courses/{email}")]
        public async Task<ObjectResult> GetCoursesForStudent(string email)
        {
            var coursesRequest = new StudentsCoursesRequest { StudentEmail = email };
            return Ok(await studentsService.GetStudentsCoursesAsync(coursesRequest));
        }

        [HttpGet("courses")]
        public async Task<ObjectResult> GetCoursesForUser()
        {
            var coursesRequest = new StudentsCoursesRequest { StudentEmail = User.Identity.Name };
            return Ok(await studentsService.GetStudentsCoursesAsync(coursesRequest));
        }
    }
}
