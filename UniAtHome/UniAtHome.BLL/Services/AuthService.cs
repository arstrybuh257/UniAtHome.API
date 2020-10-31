using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Models;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public class AuthService
    {
        private readonly UserRepository usersRepository;

        private readonly IAuthTokenGenerator tokenGenerator;

        private readonly IRefreshTokenFactory refreshTokenFactory;

        public AuthService(
            UserRepository usersRepository,
            IAuthTokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory)
        {
            this.usersRepository = usersRepository;
            this.tokenGenerator = tokenGenerator;
            this.refreshTokenFactory = refreshTokenFactory;
        }

        public async Task<RegisterResult> RegisterAsync(RegistrationRequest request)
        {
            var user = new User
            {
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
            };

            var registerResult = new RegisterResult(
                await usersRepository.TryCreateAsync(
                    user: user,
                    password: request.Password,
                    role: request.Role));

            if (registerResult.IdentityResult.Succeeded)
            {
                registerResult.UserId = user.Id;
            }

            return registerResult;
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
            Claim[] userClaims = await GetAuthTokenClaimsForUserAsync(user);

            var accessToken = tokenGenerator.GenerateTokenForClaims(userClaims);
            var refreshToken = refreshTokenFactory.GenerateRefreshToken();
            await usersRepository.CreateRefreshTokenAsync(user, refreshToken);

            return new LoginResponse
            {
                Email = user.Email,
                Token = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<TokenRefreshResponse> RefreshTokenAsync(TokenRefreshRequest request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new TokenRefreshResponse("User does not exist!");
            }

            RefreshToken token = usersRepository.GetRefreshToken(user, request.RefreshToken);
            if (token == null)
            {
                return new TokenRefreshResponse("Refresh token is not valid!");
            }

            var newRefreshToken = refreshTokenFactory.GenerateRefreshToken();
            await usersRepository.DeleteRefreshTokenAsync(user, token);
            await usersRepository.CreateRefreshTokenAsync(user, newRefreshToken);

            Claim[] tokenClaims = await GetAuthTokenClaimsForUserAsync(user);
            string newAccessToken = tokenGenerator.GenerateTokenForClaims(tokenClaims);

            return new TokenRefreshResponse
            {
                Token = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task<TokenRevokeResponse> RevokeTokenAsync(TokenRevokeRequest request)
        {
            User user = await usersRepository.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return new TokenRevokeResponse("User does not exist!");
            }

            RefreshToken refreshToken = usersRepository.GetRefreshToken(user, request.RefreshToken);
            if (refreshToken == null)
            {
                return new TokenRevokeResponse("Refresh token is not valid!");
            }

            await usersRepository.DeleteRefreshTokenAsync(user, refreshToken);
            return new TokenRevokeResponse();
        }

        private async Task<Claim[]> GetAuthTokenClaimsForUserAsync(User user)
        {
            IList<string> userRoles = await usersRepository.GetRolesAsync(user);
            var userClaims = new[]
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userRoles.FirstOrDefault())
            };
            return userClaims;
        }
    }
}
