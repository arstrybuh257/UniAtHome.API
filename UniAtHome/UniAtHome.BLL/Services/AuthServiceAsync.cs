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
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public sealed class AuthServiceAsync : IAuthServiceAsync
    {
        private UsersRepository usersRepository;

        private IAuthTokenGenerator tokenGenerator;

        private IRefreshTokenFactory refreshTokenFactory;

        public AuthServiceAsync(
            UsersRepository usersRepository,
            IAuthTokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory)
        {
            this.usersRepository = usersRepository;
            this.tokenGenerator = tokenGenerator;
            this.refreshTokenFactory = refreshTokenFactory;
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

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new LoginResponse("User does not exist!");
            }

            bool passwordIsCorrect = await usersRepository.CheckPasswordAsync(user, request.Password);
            if (!passwordIsCorrect)
            {
                return new LoginResponse("Password is incorrect!");
            }

            IList<string> userRoles = await usersRepository.GetRolesAsync(user);
            var userClaims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.FirstOrDefault())
            };

            var accessToken = tokenGenerator.GenerateTokenForClaims(userClaims);
            var refreshToken = refreshTokenFactory.GenerateRefreshToken();
            await usersRepository.CreateRefreshTokenAsync(user, refreshToken);

            return new LoginResponse
            {
                Email = user.Email,
                Token = accessToken,
                RefreshToken = refreshToken
            };

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
