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
