using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext context) : base(context)
        {
        }

        public async Task AddCourseMemberAsync(int courseId, string teacherId)
        {
            CourseMember binding = new CourseMember
            {
                CourseId = courseId,
                TeacherId = teacherId
            };
            await context.Set<CourseMember>().AddAsync(binding);
        }

        public async Task RemoveCourseMemberAsync(int courseId, string teacherId)
        {
            CourseMember binding = await context.Set<CourseMember>()
                .FirstAsync(b => b.TeacherId == teacherId && b.CourseId == courseId);
            context.Set<CourseMember>().Remove(binding);
        }

        public async Task<int?> GetCourseMemberIdAsync(int courseId, string teacherId)
        {
            var courseMember = await context.Set<CourseMember>()
                .FirstOrDefaultAsync(cm => cm.CourseId == courseId && cm.TeacherId == teacherId);
            return courseMember?.Id;
        }

        public IEnumerable<Teacher> GetCourseTeachers(int courseId)
        {
            return context.Set<CourseMember>()
                .Include(c => c.Teacher.User)
                .Where(c => c.CourseId == courseId)
                .Select(c => c.Teacher)
                .AsNoTracking()
                .ToArray();
        }

        public IEnumerable<Group> GetCourseGroups(int courseId)
        {
            return context.Set<CourseMember>()
                .Where(c => c.CourseId == courseId)
                .SelectMany(c => c.Groups)
                .AsNoTracking()
                .ToArray();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await context.Set<Course>()
                .Include(c=>c.CourseMembers)
                .ThenInclude(m=>m.Teacher)
                .ThenInclude(t=>t.User)
                .Where(c=>c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Course> GetCourseWithLessonsByIdAsync(int id)
        {
            return await context.Set<Course>()
                .Include(c => c.Lessons)
                .Where(c => c.Id == id).FirstOrDefaultAsync();
        }
    }
}
