using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniAtHome.DAL.Constants;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL
{
    public static class ModelBuilderExtensions
    {
        private const string ADMIN_ROLE_ID = "2AEFE1C5-C5F0-4399-8FB8-420813567554";
        private const string UNIVERSITY_ADMIN_ROLE_ID = "99DA7670-5471-414F-834E-9B3A6B6C8F6F";
        private const string TEACHER_ROLE_ID = "828A3B02-77C0-45C1-8E97-6ED57711E577";
        private const string STUDENT_ROLE_ID = "422EEB6A-3031-4B66-ABA8-0F85AFC07C3C";

        private const string ADMIN_USER_ID = "00CA41A9-C962-4230-937E-D5F54772C062";
        private const string TEACHER_USER_ID = "E8D13331-62AB-463E-A283-6493B68A3622";
        private const string STUDENT_USER_ID = "E3A6BF34-A57D-4709-97CC-6AD1B2B3985B";

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
                Name = RoleName.ADMIN,
                NormalizedName = RoleName.ADMIN.ToUpper()
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = UNIVERSITY_ADMIN_ROLE_ID,
                Name = RoleName.UNIVERSITY_ADMIN,
                NormalizedName = RoleName.UNIVERSITY_ADMIN.ToUpper()
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = TEACHER_ROLE_ID,
                Name = RoleName.TEACHER,
                NormalizedName = RoleName.TEACHER.ToUpper()
            });

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = STUDENT_ROLE_ID,
                Name = RoleName.STUDENT,
                NormalizedName = RoleName.STUDENT.ToUpper()
            });
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            SeedUser(
                modelBuilder: modelBuilder,
                id: ADMIN_USER_ID,
                firstName: "Admin",
                lastName: "Adminovich",
                email: "admin@gmail.com",
                password: "Qwerty12345",
                roleId: ADMIN_ROLE_ID);

            SeedUser(
                modelBuilder: modelBuilder,
                id: TEACHER_USER_ID,
                firstName: "Ihor",
                lastName: "Juice",
                email: "ihor.juice@gmail.com",
                password: "Qwerty12345",
                roleId: TEACHER_ROLE_ID);

            SeedUser(
                modelBuilder: modelBuilder,
                id: STUDENT_USER_ID,
                firstName: "Slava",
                lastName: "Ivanov",
                email: "slava.ivanov@gmail.com",
                password: "Qwerty12345",
                roleId: STUDENT_ROLE_ID);
        }

        private static void SeedUser(
            ModelBuilder modelBuilder,
            string id, 
            string firstName, 
            string lastName, 
            string email, 
            string password,
            string roleId)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                UserName = email,
                NormalizedUserName = email,
                Email = email,
                NormalizedEmail = email,
                PasswordHash = new PasswordHasher<User>().HashPassword(null, password)
            });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = id
            });

            switch (roleId)
            {
                case TEACHER_ROLE_ID:
                    modelBuilder.Entity<Teacher>().HasData(new Teacher { UserId = id });
                    break;
                case STUDENT_ROLE_ID:
                    modelBuilder.Entity<Student>().HasData(new Student { UserId = id });
                    break;
                default: break;
            }
        }
    }
}
