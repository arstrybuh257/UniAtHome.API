using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseEntity
    {
        protected readonly DbContext context;

        public Repository(DbContext context)
        {
            this.context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T item)
        {
            await context.Set<T>().AddAsync(item);
        }
    }
}
