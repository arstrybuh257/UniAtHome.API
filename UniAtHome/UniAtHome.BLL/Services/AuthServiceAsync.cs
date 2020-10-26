using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
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

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var user = new User
            {
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };
            var registerResult = await usersRepository.TryCreateAsync(
                user: user,
                password: request.Password,
                role: request.Role);

            if (!registerResult.Succeeded)
            {
                return new RegistrationResponse(registerResult.Errors);
            }

            return new RegistrationResponse();
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


        public Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<object> RefreshTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TokenRefreshResponse> RefreshTokenAsync(TokenRefreshRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TokenRevokeResponse> RevokeTokenAsync(TokenRevokeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
