using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.WebAPI.Models.UsersRequests;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        private readonly IAuthTokenGenerator tokenGenerator;

        public UsersController(UserManager<User> userManager, IAuthTokenGenerator tokenGenerator)
        {
            this.userManager = userManager;
            this.tokenGenerator = tokenGenerator;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<object> Register([FromBody] RegistrationRequest registerModel)
        {
            var user = new User
            {
                UserName = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email
            };
            var registerResult = await userManager.CreateAsync(user, registerModel.Password);
            if (registerResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, registerModel.Role);
                return Ok("User is successfully registered!");
            }

            return GetErrorOfNotSucceededRequest(registerResult);
        }

        private ObjectResult GetErrorOfNotSucceededRequest(IdentityResult registerResult)
        {
            var errors = new ArrayList();
            errors.AddRange(registerResult.Errors.Select(
                error => new
                {
                    code = error.Code,
                    message = error.Description
                })
                .ToArray());
            return BadRequest(errors);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<object> Login([FromBody] LoginRequest loginModel)
        {
            var identity = await GetIdentity(loginModel);
            if (identity == null)
            {
                return BadRequest("Either email or password is incorrect.");
            }

            var accessToken = tokenGenerator.GenerateTokenForClaims(identity.Claims);
            return new { AccessToken = accessToken };
        }

        private async Task<ClaimsIdentity> GetIdentity(LoginRequest loginModel)
        {
            User user = await userManager.FindByEmailAsync(loginModel.Email);
            if (user != null) 
            {
                bool passwordIsCorrect = await userManager.CheckPasswordAsync(user, loginModel.Password);
                var userRoles = await userManager.GetRolesAsync(user);
                if (passwordIsCorrect)
                {
                    var userClaims = new[]
                    {
                        new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                        new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.FirstOrDefault())
                    };
                    return new ClaimsIdentity(userClaims, JwtBearerDefaults.AuthenticationScheme, ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                }
            }

            return null;
        }

        [Authorize]
        [HttpGet("check")]
        public ActionResult<string> CheckAuthorization()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public ActionResult<string> CheckAdmin()
        {
            return Ok();
        }
    }
}
