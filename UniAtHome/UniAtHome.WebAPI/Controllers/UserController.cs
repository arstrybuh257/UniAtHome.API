using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Models.Users;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthServiceAsync authService;

        public UserController(IAuthServiceAsync authService)
        {
            this.authService = authService;
        }

        [Authorize(Roles = "Admin")]
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
            HttpContext.Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });
            return Ok(new LoginApiResponse
            {
                Email = response.Email,
                Token = response.Token
            });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ObjectResult> Refresh()
        {
            bool hasToken = HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues tokenHeader);
            string token = tokenHeader.ToString().Substring("Bearer ".Length);
            string refreshToken = HttpContext.Request.Cookies["refreshToken"];
            var request = new TokenRefreshRequest
            {
                AuthToken = token,
                RefreshToken = refreshToken
            };

            TokenRefreshResponse response = await authService.RefreshTokenAsync(request);
            if (!response.Success)
            {
                return BadRequest(response.Errors);
            }

            HttpContext.Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });
            return Ok(new TokenRefreshApiResponse
            {
                Token = response.Token
            });
        }

        [Authorize]
        [HttpPost("revoke")]
        public async Task<ObjectResult> Revoke()
        {
            string userEmail = User.Identity.Name;
            string refreshToken = HttpContext.Request.Cookies["refreshToken"];

            var request = new TokenRevokeRequest
            {
                Email = userEmail,
                RefreshToken = refreshToken
            };

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
