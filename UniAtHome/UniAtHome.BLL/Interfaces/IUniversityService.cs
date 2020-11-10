using System.Threading.Tasks;

namespace UniAtHome.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<bool> HasUniversityAdmin(int unversityId, string userName);

        Task<bool> HasTeacher(int unversityId, string userName);

        Task<bool> HasStudent(int unversityId, string userName);
    }
}
