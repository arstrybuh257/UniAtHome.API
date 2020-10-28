using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var adminRoleId = SeedRoleAndGetId(modelBuilder, "Admin");
            var univAdminRoleId = SeedRoleAndGetId(modelBuilder, "UniversityAdmin");

            var admin = new User
            {
                Id = new Guid().ToString(),
                FirstName = "Admin",
                LastName = "Adminovich",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Qwerty12345")
            };
            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = admin.Id
            });
        }

        private static string SeedRoleAndGetId(ModelBuilder modelBuilder, string roleName)
        {
            IdentityRole newRole = new IdentityRole
            {
                Id = new Guid().ToString(),
                Name = roleName,
                NormalizedName = roleName.ToUpper()
            };
            modelBuilder.Entity<IdentityRole>().HasData(newRole);
            return newRole.Id;
        }
    }
}
