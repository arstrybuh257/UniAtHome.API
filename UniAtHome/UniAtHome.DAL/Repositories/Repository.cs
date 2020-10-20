using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public class Repository : IRepository<BaseEntity> 
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<BaseEntity> GetByIdAsync(int id)
        {
            return await context.Set<BaseEntity>().FindAsync(id);
        }

        public async Task AddAsync(BaseEntity item)
        {
            await context.Set<BaseEntity>().AddAsync(item);
        }
    }
}
