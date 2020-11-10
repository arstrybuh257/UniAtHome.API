using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface IUniversityRepository : IRepository<University>
    {
        Task<bool> HasUniversityAdminAsync(int universityId, string userName);

        Task<bool> HasTeacherAsync(int universityId, string userName);

        Task<bool> HasStudentAsync(int universityId, string userName);
    }
}
