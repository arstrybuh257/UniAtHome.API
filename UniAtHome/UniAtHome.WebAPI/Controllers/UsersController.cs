using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.WebAPI.Extensions;
using UniAtHome.WebAPI.Models;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> userManager;

        private readonly IConfiguration configuration;

        public UsersController(UserManager<User> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.configuration = configuration;
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
                return new { error = "Either email or password is incorrect." };
            }

            var now = DateTime.UtcNow;
            var authOptions = new AuthTokenValidationOptions(configuration);
            var jwt = new JwtSecurityToken(
                    issuer: authOptions.ValidIssuer,
                    audience: authOptions.ValidAudience,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(authOptions.LifetimeMinutes)),
                    signingCredentials: new SigningCredentials(authOptions.IssuerSigningKey, SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return response;
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
