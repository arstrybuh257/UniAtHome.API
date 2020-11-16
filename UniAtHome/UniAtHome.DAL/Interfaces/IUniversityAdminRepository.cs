using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface IUniversityAdminRepository : IRepository<UniversityAdmin>
    {
        Task<UniversityAdmin> GetByIdAsync(string id);
    }
}
