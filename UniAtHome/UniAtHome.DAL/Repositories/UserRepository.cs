using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public class UserRepository
    {
        private readonly DbContext context;

        private readonly UserManager<User> userManager;

        private readonly int refreshTokenLifetime;

        public UserRepository(
            DbContext context,
            UserManager<User> userManager, 
            IConfiguration config)
        {
            this.context = context;
            this.userManager = userManager;
            this.refreshTokenLifetime = config.GetValue<int>("RefreshTokenLifetimeMinutes");
        }

        public async Task<IdentityResult> TryCreateAsync(User user, string password)
        {
            var addingResult = await userManager.CreateAsync(user, password);
            return addingResult;
        }

        public async Task AddUserToRoleAsync(User user, string role)
        {
            await userManager.AddToRoleAsync(user, role);
        }

        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            return userManager.CheckPasswordAsync(user, password);
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return userManager.FindByEmailAsync(email);
        }

        public Task<IList<string>> GetRolesAsync(User user)
        {
            return userManager.GetRolesAsync(user);
        }

        public async Task CreateRefreshTokenAsync(User user, string refreshToken)
        {
            var newToken = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                ExpirationDate = DateTimeOffset.UtcNow.AddMinutes(refreshTokenLifetime),
            };
            context.Set<RefreshToken>().Add(newToken);
            await context.SaveChangesAsync(); // I'm not sure when and where to put it 
        }

        public RefreshToken GetRefreshToken(User user, string refreshToken)
        {
            return context.Set<RefreshToken>()
                .FirstOrDefault(token => token.UserId == user.Id && token.Token == refreshToken);
        }

        public async Task DeleteRefreshTokenAsync(RefreshToken refreshToken)
        {
            context.Set<RefreshToken>().Remove(refreshToken);
            await context.SaveChangesAsync(); // I'm not sure when and where to put it 
        }
    }
}
