using System.Threading.Tasks;

namespace UniAtHome.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<bool> HasUniversityAdminAsync(int universityId, string userName);

        Task<bool> HasTeacherAsync(int universityId, string userName);

        Task<bool> HasStudentAsync(int universityId, string userName);
    }
}
