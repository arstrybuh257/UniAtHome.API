using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository universityRepository;

        public UniversityService(IUniversityRepository universityRepository)
        {
            this.universityRepository = universityRepository;
        }

        public Task<bool> HasUniversityAdminAsync(int universityId, string userName)
        {
            return universityRepository.HasUniversityAdminAsync(universityId, userName);
        }

        public Task<bool> HasTeacherAsync(int universityId, string userName)
        {
            return universityRepository.HasTeacherAsync(universityId, userName);
        }

        public Task<bool> HasStudentAsync(int universityId, string userName)
        {
            return universityRepository.HasStudentAsync(universityId, userName);
        }
    }
}
