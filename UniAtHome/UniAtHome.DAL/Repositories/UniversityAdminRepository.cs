using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public class UniversityAdminRepository : Repository<UniversityAdmin>, IUniversityAdminRepository
    {
        public UniversityAdminRepository(DbContext context) : base(context)
        {
        }

        public async Task<UniversityAdmin> GetByIdAsync(string id)
        {
            return await context.Set<UniversityAdmin>().FirstOrDefaultAsync(s => s.UserId == id);
        }
    }
}
