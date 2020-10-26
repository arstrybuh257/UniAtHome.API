using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
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
        public async Task<ActionResult> Register([FromBody] RegistrationRequest request)
        {
            var response = await authService.RegisterAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ObjectResult> Login([FromBody] LoginRequest request)
        {
            var response = await authService.LoginAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ObjectResult> Refresh([FromBody] TokenRefreshRequest request)
        {
            var response = await authService.RefreshTokenAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
        }

        [Authorize]
        [HttpPost("revoke")]
        public async Task<ObjectResult> Revoke([FromBody] TokenRevokeRequest request)
        {
            var response = await authService.RevokeTokenAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }

            return Ok(response);
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
