using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UserRequests;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public sealed class AuthServiceAsync : IAuthServiceAsync
    {
        private UsersRepository usersRepository;

        private IAuthTokenGenerator tokenGenerator;

        public AuthServiceAsync(UsersRepository usersRepository, IAuthTokenGenerator tokenGenerator)
        {
            this.usersRepository = usersRepository;
            this.tokenGenerator = tokenGenerator;
        }

        public async Task<IEnumerable<object>> TryRegisterAndReturnErrorsAsync(RegistrationRequest registerModel)
        {
            var user = new User
            {
                UserName = registerModel.Email,
                FirstName = registerModel.FirstName,
                LastName = registerModel.LastName,
                Email = registerModel.Email,
            };
            var registerResult = await usersRepository.TryCreateAsync(
                user: user,
                password: registerModel.Password,
                role: registerModel.Role);

            if (registerResult.Succeeded)
            {
                return Enumerable.Empty<object>();
            }

            return GetErrorOfNotSucceededRequest(registerResult);
        }

        private IEnumerable<object> GetErrorOfNotSucceededRequest(IdentityResult registerResult)
        {
            var errors = new List<object>();
            errors.AddRange(registerResult.Errors.Select(
                error => new
                {
                    code = error.Code,
                    message = error.Description
                })
                .ToArray());
            return errors;
        }

        public async Task<object> GetAuthTokenAsync(LoginRequest loginModel)
        {
            var identity = await GetIdentity(loginModel);
            if (identity == null)
            {
                return null;
            }
            var accessToken = tokenGenerator.GenerateTokenForClaims(identity.Claims);
            return new { AccessToken = accessToken };
        }

        private async Task<ClaimsIdentity> GetIdentity(LoginRequest loginModel)
        {
            User user = await usersRepository.FindByEmailAsync(loginModel.Email);
            if (user != null)
            {
                bool passwordIsCorrect = await usersRepository.CheckPasswordAsync(user, loginModel.Password);
                IList<string> userRoles = await usersRepository.GetRolesAsync(user);
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

        public Task<object> RefreshTokenAsync()
        {
            throw new NotImplementedException();
        }
    }
}
