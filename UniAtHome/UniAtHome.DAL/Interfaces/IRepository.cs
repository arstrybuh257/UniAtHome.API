using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace UniAtHome.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task AddAsync(T item);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<T> GetSingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(int id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        Task SaveChangesAsync();

        void Update(T entity);

        public Task<IEnumerable<T>> GetAllAsync();
    }
}
