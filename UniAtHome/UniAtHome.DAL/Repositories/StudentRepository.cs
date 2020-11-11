using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public sealed class StudentRepository : Repository<Student>, IRepository<Student>
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

    }
    public sealed class GroupRepository : Repository<Group>, IRepository<Group>
    {
        public GroupRepository(DbContext context) : base(context)
        {
        }

        public async Task AddStudentToGroupAsync(int groupId, string studentId)
        {
            var studentGroup = new StudentGroup
            {
                GroupId = groupId,
                StudentId = studentId
            };
            await context.Set<StudentGroup>().AddAsync(studentGroup);
        }

        public async Task RemoveStudentFromGroupAsync(int groupId, string studentId)
        {
            StudentGroup binding = await context.Set<StudentGroup>().FirstOrDefaultAsync(
                b => b.StudentId == studentId && b.GroupId == groupId);
            context.Set<StudentGroup>().Remove(binding);
        }

        public IEnumerable<Student> GetGroupStudents(int groupId)
        {
            return context.Set<Group>()
                .Where(g => g.Id == groupId)
                .SelectMany(g => g.StudentGroups)
                .Select(gr => gr.Student)
                .AsNoTracking()
                .ToArray();
        }
    }
}
