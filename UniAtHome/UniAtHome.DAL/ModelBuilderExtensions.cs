using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL
{
    public static class ModelBuilderExtensions
    {
        private const string ADMIN_ROLE_ID = "2AEFE1C5-C5F0-4399-8FB8-420813567554";
        private const string UNIVERSITY_ADMIN_ROLE_ID = "99DA7670-5471-414F-834E-9B3A6B6C8F6F";

        private const string ADMIN_USER_ID = "00CA41A9-C962-4230-937E-D5F54772C062";

        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedRoles(modelBuilder);
            SeedUsers(modelBuilder);
        }

        private static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = UNIVERSITY_ADMIN_ROLE_ID,
                Name = "UniversityAdmin",
                NormalizedName = "UNIVERSITYADMIN"
            });
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = ADMIN_USER_ID,
                FirstName = "Admin",
                LastName = "Adminovich",
                UserName = "admin@gmail.com",
                NormalizedUserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                PasswordHash = new PasswordHasher<User>().HashPassword(null, "Qwerty12345")
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_USER_ID
            });
        }
    }
}
