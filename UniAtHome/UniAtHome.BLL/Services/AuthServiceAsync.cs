using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public sealed class AuthServiceAsync : IAuthServiceAsync
    {
        private readonly UsersRepository usersRepository;

        private readonly IRepository<Teacher> teachersRepository;

        private readonly IRepository<Student> studentsRepository;

        private readonly IAuthTokenGenerator tokenGenerator;

        private readonly IRefreshTokenFactory refreshTokenFactory;

        public AuthServiceAsync(
            UsersRepository usersRepository,
            IRepository<Teacher> teachersRepository,
            IRepository<Student> studentsRepository,
            IAuthTokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory)
        {
            this.usersRepository = usersRepository;
            this.teachersRepository = teachersRepository;
            this.studentsRepository = studentsRepository;
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

            switch (request.Role)
            {
                case RoleName.TEACHER:
                    await teachersRepository.AddAsync(new Teacher { UserId = user.Id });
                    await teachersRepository.SaveChangesAsync();
                    break;
                case RoleName.STUDENT:
                    await studentsRepository.AddAsync(new Student { UserId = user.Id });
                    await studentsRepository.SaveChangesAsync();
                    break;
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
    }
}
