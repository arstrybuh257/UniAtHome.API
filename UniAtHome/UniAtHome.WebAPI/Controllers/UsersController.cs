using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UserRequests;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthServiceAsync authService;

        public UsersController(IAuthServiceAsync authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegistrationRequest registerModel)
        {
            var errors = await authService.TryRegisterAndReturnErrorsAsync(registerModel);
            if (!errors.Any())
            {
                return Ok();
            }
            return BadRequest(errors);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginRequest loginModel)
        {
            var token = await authService.GetAuthTokenAsync(loginModel);
            if (token == null)
            {
                return BadRequest("Either email or password is incorrect.");
            }

            return token;
        }

        [Authorize]
        [HttpGet("check")]
        public ActionResult<string> CheckAuthorization()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("checkAdmin")]
        public ActionResult<string> CheckAdmin()
        {
            return Ok();
        }
    }
}
