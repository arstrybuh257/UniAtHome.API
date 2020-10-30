using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
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

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await this.context.Set<T>().Where(predicate).AsNoTracking().ToListAsync();
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await this.context.Set<T>().AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            this.context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            this.context.Set<T>().RemoveRange(entities);
        }

        public void Update(T entity)
        {
            this.context.Set<T>().Update(entity);
        }
    }
}
