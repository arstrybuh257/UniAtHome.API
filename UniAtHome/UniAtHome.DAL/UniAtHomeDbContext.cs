using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL
{
    public class UniAtHomeDbContext : IdentityDbContext<User>
    {
        public UniAtHomeDbContext(DbContextOptions<UniAtHomeDbContext> options) : base(options)
        {
        }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<CourseMember> CourseMembers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            //User
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(30);

            //Student
            modelBuilder.Entity<Student>().HasKey(s => s.UserId);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne();
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentGroups)
                .WithOne(sg => sg.Student)
                .HasForeignKey(sg=>sg.StudentId);

            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(t => t.UserId);
            modelBuilder.Entity<Teacher>()
                .HasOne(t=>t.User)
                .WithOne();
            modelBuilder.Entity<Teacher>()
                .HasMany(t=>t.CourseMembers)
                .WithOne(cm=>cm.Teacher)
                .HasForeignKey(cm=>cm.TeacherId);

            //Course
            modelBuilder.Entity<Course>().HasKey(ct => ct.Id);
            modelBuilder.Entity<Course>().Property(c => c.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Course>().Property(c => c.Description).HasMaxLength(2000);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseMembers)
                .WithOne(cm => cm.Course)
                .HasForeignKey(cm => cm.CourseId);

            modelBuilder.Entity<CourseMember>().HasKey(cm => cm.Id);

            //Group
            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Group>()
                .HasMany(g=>g.StudentGroups)
                .WithOne(sg=>sg.Group)
                .HasForeignKey(sg=>sg.GroupId);
            modelBuilder.Entity<Group>()
                .HasMany(g=>g.Timetables)
                .WithOne(tt=>tt.Group)
                .HasForeignKey(tt=>tt.GroupId);
            modelBuilder.Entity<Group>()
                .HasOne(g=>g.CourseMember)
                .WithMany(cm=>cm.Groups)
                .HasForeignKey(g=>g.CourseMemberId);

            //StudentGroup
            modelBuilder.Entity<StudentGroup>().HasKey(sg=>new{sg.StudentId, sg.GroupId});

            //Lesson
            modelBuilder.Entity<Lesson>().HasKey(l=>l.Id);
            modelBuilder.Entity<Lesson>().Property(l=>l.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Lesson>().Property(l => l.Description).HasMaxLength(2000);
            modelBuilder.Entity<Lesson>()
                .HasMany(l=>l.Timetables)
                .WithOne(tt=>tt.Lesson)
                .HasForeignKey(tt=>tt.LessonId);

            //Timetable
            modelBuilder.Entity<Timetable>().HasKey(tt => new { tt.GroupId, tt.LessonId });

            // Refresh token
            modelBuilder.Entity<RefreshToken>().HasKey(rt => rt.Id);
            modelBuilder.Entity<RefreshToken>().Property(rt => rt.Token).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<RefreshToken>().Property(rt => rt.ExpirationDate).IsRequired();
            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(user => user.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateAuditableEntity();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            UpdateAuditableEntity();
            return base.SaveChanges();
        }

        private void UpdateAuditableEntity()
        {
            foreach (var auditableEntity in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (auditableEntity.State == EntityState.Added || auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.Modified = DateTime.Now;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.Added = DateTime.Now;
                    }
                }
            }
        }
    }
}
