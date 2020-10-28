using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task AddAsync(T item);
    }
}
