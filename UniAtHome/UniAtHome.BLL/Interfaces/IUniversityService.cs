using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.University;

namespace UniAtHome.BLL.Interfaces
{
    public interface IUniversityService
    {
        Task<bool> HasUniversityAdminAsync(int universityId, string userName);

        Task<bool> HasTeacherAsync(int universityId, string userName);

        Task<bool> HasStudentAsync(int universityId, string userName);

        Task<IEnumerable<UniversityDTO>> GetUniversities();

        Task<bool> DeleteUniversityAsync(int universityId);
    }
}
