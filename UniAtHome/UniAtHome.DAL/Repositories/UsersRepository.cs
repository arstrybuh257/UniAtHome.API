using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Repositories
{
    public sealed class UsersRepository
    {
        private UserManager<User> userManager;

        public UsersRepository(UserManager<User> userManager)
        {
            this.userManager = userManager;
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
    }
}
