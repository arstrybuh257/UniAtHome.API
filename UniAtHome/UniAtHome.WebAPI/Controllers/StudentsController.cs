using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(await studentsService.GetStudentsCoursesAsync(email));
        }

        [HttpGet("courses")]
        public async Task<ObjectResult> GetCoursesForUser()
        {
            return Ok(await studentsService.GetStudentsCoursesAsync(User.Identity.Name));
        }
    }
}
