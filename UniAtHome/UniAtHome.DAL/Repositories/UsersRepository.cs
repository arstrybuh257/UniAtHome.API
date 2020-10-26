using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Repositories
{
    public sealed class UsersRepository
    {
        private readonly UniAtHomeDbContext context;

        private readonly UserManager<User> userManager;

        private readonly int refreshTokenLifetime;

        public UsersRepository(
            UniAtHomeDbContext context,
            UserManager<User> userManager, 
            IConfiguration config)
        {
            this.context = context;
            this.userManager = userManager;
            this.refreshTokenLifetime = config.GetValue<int>("RefreshTokenLifetimeMinutes");
        }

        public async Task<IdentityResult> TryCreateAsync(User user, string password, string role)
        {
            var addingResult = await userManager.CreateAsync(user, password);
            if (addingResult.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
            return addingResult;
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
                User = user,
                ExpirationDate = DateTime.Now.AddMinutes(refreshTokenLifetime),
            };
            context.RefreshTokens.Add(newToken);
            await context.SaveChangesAsync(); // I'm not sure when and where to put it 
        }

        public RefreshToken GetRefreshToken(User user, string refreshToken)
        {
            return context.RefreshTokens
                .FirstOrDefault(token => token.UserId == user.Id && token.Token == refreshToken);
        }

        public async Task DeleteRefreshTokenAsync(User user, RefreshToken refreshToken)
        {
            context.RefreshTokens.Remove(refreshToken);
            await context.SaveChangesAsync(); // I'm not sure when and where to put it 
        }
    }
}
