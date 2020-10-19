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
                if (passwordIsCorrect)
                {
                    var userClaims = await userManager.GetClaimsAsync(user);
                    userClaims.Add(new Claim("UserId<==", user.Id));
                    return new ClaimsIdentity(userClaims, "Token");
                }
            }

            return null;
        }
    }
}
