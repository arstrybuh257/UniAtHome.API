using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public sealed class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(DbContext context) : base(context)
        {
        }

        public async Task<Student> GetByIdAsync(string id)
        {
            return await context.Set<Student>().FirstOrDefaultAsync(s => s.UserId == id);
        }

        public async Task<Student> GetByEmailAsync(string email)
        {
            return await context.Set<Student>()
                .Include(t => t.User)
                .FirstOrDefaultAsync(t => t.User.Email == email);
        }
    }
}
