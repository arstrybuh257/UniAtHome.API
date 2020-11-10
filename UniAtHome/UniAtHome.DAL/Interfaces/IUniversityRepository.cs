using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface IUniversityRepository : IRepository<University>
    {
        Task<bool> HasUniversityAdmin(int unversityId, string userId);

        Task<bool> HasTeacher(int unversityId, string userId);

        Task<bool> HasStudent(int unversityId, string userId);
    }
}
