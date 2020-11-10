using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Models.Users;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService;

        public UserController(IAuthService authService)
        {
            this.authService = authService;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegistrationDTO request)
        {
            await authService.RegisterAsync(request);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ObjectResult> Login([FromBody] LoginRequestDTO request)
        {
            var response = await authService.LoginAsync(request);

            HttpContext.Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });
            return Ok(new LoginApiResponse
            {
                AccessToken = "Bearer " + response.Token
            });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ObjectResult> Refresh()
        {
            bool hasToken = HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues tokenHeader);
            if (!hasToken)
            {
                throw new BadRequestException("Provide the expired token in the Athorization header!");
            }

            string token = tokenHeader.ToString().Substring("Bearer ".Length);
            string refreshToken = HttpContext.Request.Cookies["refreshToken"];
            var request = new TokenRefreshRequestDTO
            {
                AuthToken = token,
                RefreshToken = refreshToken
            };

            TokenRefreshResponseDTO response = await authService.RefreshTokenAsync(request);

            HttpContext.Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });
            return Ok(new TokenRefreshApiResponse
            {
                AccessToken = "Bearer " + response.Token
            });
        }

        [Authorize]
        [HttpPost("revoke")]
        public async Task<IActionResult> Revoke()
        {
            string userEmail = User.Identity.Name;
            string refreshToken = HttpContext.Request.Cookies["refreshToken"];

            var request = new TokenRevokeDTO
            {
                Email = userEmail,
                RefreshToken = refreshToken
            };

            await authService.RevokeTokenAsync(request);

            return Ok();
        }

        [Authorize, HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            string email = User.Identity.Name;
            UserInfoResponseDTO response = await authService.GetUserInfoAsync(email);

            return Ok(new UserInfoApiResponse
            {
                Email = response.Email,
                FirstName = response.FirstName,
                LastName = response.LastName,
                Role = response.Role
            });
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
