﻿using System;
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

        public DbSet<UniversityAdmin> UniversityAdmins { get; set; }

        public DbSet<University> Universities { get; set; }

        public DbSet<StudentGroup> StudentGroups { get; set; }

        public DbSet<Timetable> Timetables { get; set; }

        public DbSet<CourseMember> CourseMembers { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<UniversityCreateRequest> UniversityCreateRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();

            //User
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.FirstName).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<User>().Property(u => u.LastName).IsRequired().HasMaxLength(30);

            // University
            modelBuilder.Entity<University>().HasKey(un => un.Id);
            modelBuilder.Entity<University>().Property(un => un.Name).HasMaxLength(200);
            modelBuilder.Entity<University>().Property(un => un.ShortName).HasMaxLength(20);
            modelBuilder.Entity<University>().Property(un => un.Address).HasMaxLength(400);
            modelBuilder.Entity<University>().Property(un => un.Country).HasMaxLength(50);

            // University admin
            modelBuilder.Entity<UniversityAdmin>().HasKey(a => a.UserId);
            modelBuilder.Entity<UniversityAdmin>()
                .HasOne(a => a.User)
                .WithOne();
            modelBuilder.Entity<UniversityAdmin>()
                .HasOne(a => a.University)
                .WithMany(un => un.UniversityAdmins)
                .HasForeignKey(s => s.UniversityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Student
            modelBuilder.Entity<Student>().HasKey(s => s.UserId);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne();
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentGroups)
                .WithOne(sg => sg.Student)
                .HasForeignKey(sg => sg.StudentId);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.University)
                .WithMany(un => un.Students)
                .HasForeignKey(s => s.UniversityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Teacher
            modelBuilder.Entity<Teacher>().HasKey(t => t.UserId);
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne();
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.CourseMembers)
                .WithOne(cm => cm.Teacher)
                .HasForeignKey(cm => cm.TeacherId);
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.University)
                .WithMany(un => un.Teachers)
                .HasForeignKey(t => t.UniversityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            //Course
            modelBuilder.Entity<Course>().HasKey(ct => ct.Id);
            modelBuilder.Entity<Course>().Property(c => c.Name).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Course>().Property(c => c.Description).HasMaxLength(2000);
            modelBuilder.Entity<Course>().Property(c => c.ImagePath).HasMaxLength(200);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseMembers)
                .WithOne(cm => cm.Course)
                .HasForeignKey(cm => cm.CourseId);
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Lessons)
                .WithOne(cm => cm.Course)
                .HasForeignKey(cm => cm.CourseId);
            modelBuilder.Entity<Course>()
                .HasOne(c => c.University)
                .WithMany(un => un.Courses)
                .HasForeignKey(c => c.UniversityId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Course member
            modelBuilder.Entity<CourseMember>().HasKey(cm => cm.Id);

            //Group
            modelBuilder.Entity<Group>().HasKey(g => g.Id);
            modelBuilder.Entity<Group>()
                .Property(g => g.Name)
                .IsRequired();
            modelBuilder.Entity<Group>()
                .HasMany(g => g.StudentGroups)
                .WithOne(sg => sg.Group)
                .HasForeignKey(sg => sg.GroupId);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.Timetables)
                .WithOne(tt => tt.Group)
                .HasForeignKey(tt => tt.GroupId);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.CourseMember)
                .WithMany(cm => cm.Groups)
                .HasForeignKey(g => g.CourseMemberId);

            //StudentGroup
            modelBuilder.Entity<StudentGroup>().HasKey(sg => new { sg.StudentId, sg.GroupId });

            //Lesson
            modelBuilder.Entity<Lesson>().HasKey(l => l.Id);
            modelBuilder.Entity<Lesson>().Property(l => l.Title).IsRequired().HasMaxLength(200);
            modelBuilder.Entity<Lesson>().Property(l => l.Description).HasMaxLength(2000);
            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Timetables)
                .WithOne(tt => tt.Lesson)
                .HasForeignKey(tt => tt.LessonId).OnDelete(DeleteBehavior.NoAction);

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

            // University create requests
            modelBuilder.Entity<UniversityCreateRequest>().HasKey(r => r.Id);
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.UniversityName).IsRequired();
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.UniversityShortName).IsRequired();
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.Address);
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.Country).IsRequired();
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.SubmitterFirstName).IsRequired();
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.SubmitterLastName).IsRequired();
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.Email).IsRequired();
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.Comment);
            modelBuilder.Entity<UniversityCreateRequest>().Property(r => r.DateOfCreation).IsRequired();
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
