using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Users;

namespace UniAtHome.WebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class UserController : ControllerBase
    {
        private readonly IAuthService authService;

        private readonly IUniversityService universityService;

        private readonly IMapper mapper;

        public UserController(IAuthService authService, IUniversityService universityService, IMapper mapper)
        {
            this.authService = authService;
            this.universityService = universityService;
            this.mapper = mapper;
        }

        [Authorize(Roles = RoleName.ADMIN)]
        [HttpPost("registerAdmin")]
        public async Task<ActionResult> RegisterAdminAsync([FromBody] AdminRegistrationRequest request)
        {
            var dto = mapper.Map<AdminRegistrationDTO>(request);
            await authService.RegisterAdminAsync(dto);

            return Ok();
        }

        [Authorize(Roles = RoleName.ADMIN + "," + RoleName.UNIVERSITY_ADMIN)]
        [HttpPost("registerUniversityAdmin")]
        public async Task<ActionResult> RegisterUniversityAdminAsync([FromBody] UniversityAdminRegistrationRequest request)
        {
            if (!await User.IsUniversityAdminOrHigherAsync(request.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights!");
            }

            var dto = mapper.Map<UniversityAdminRegistrationDTO>(request);
            await authService.RegisterUniversityAdminAsync(dto);

            return Ok();
        }

        [Authorize(Roles = RoleName.ADMIN + "," + RoleName.UNIVERSITY_ADMIN)]
        [HttpPost("registerTeacher")]
        public async Task<ActionResult> RegisterTeacherAsync([FromBody] TeacherRegistrationRequest request)
        {
            if (!await User.IsUniversityAdminOrHigherAsync(request.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights!");
            }

            var dto = mapper.Map<TeacherRegistrationDTO>(request);
            await authService.RegisterTeacherAsync(dto);

            return Ok();
        }

        [Authorize(Roles = RoleName.ADMIN + "," + RoleName.UNIVERSITY_ADMIN)]
        [HttpPost("registerStudent")]
        public async Task<ActionResult> RegisterStudentAsync([FromBody] StudentRegistrationRequest request)
        {
            if (!await User.IsUniversityAdminOrHigherAsync(request.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights!");
            }

            var dto = mapper.Map<StudentRegistrationDTO>(request);
            await authService.RegisterStudentAsync(dto);

            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ObjectResult> LoginAsync([FromBody] LoginRequestDTO request)
        {
            var response = await authService.LoginAsync(request);

            HttpContext.Response.Cookies.Append("refreshToken", response.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true
            });
            return Ok(new LoginResponse
            {
                AccessToken = "Bearer " + response.Token
            });
        }

        [AllowAnonymous]
        [HttpPost("refresh")]
        public async Task<ObjectResult> RefreshAsync()
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
            return Ok(new TokenRefreshResponse
            {
                AccessToken = "Bearer " + response.Token
            });
        }

        [Authorize]
        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeAsync()
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
        public async Task<IActionResult> GetUserInfoAsync()
        {
            string email = User.Identity.Name;
            UserInfoResponseDTO response = await authService.GetUserInfoAsync(email);

            return Ok(new UserInfoResponse
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
