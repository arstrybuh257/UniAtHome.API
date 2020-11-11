using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public sealed class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(DbContext context) : base(context)
        {
        }

        public async Task<Teacher> GetByIdAsync(string id)
        {
            return await context.Set<Teacher>().FirstOrDefaultAsync(t => t.UserId == id);
        }
    }
}
