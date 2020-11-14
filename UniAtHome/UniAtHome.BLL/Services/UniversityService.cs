using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using UniAtHome.BLL.DTOs.University;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class UniversityService : IUniversityService
    {
        private readonly IUniversityRepository universityRepository;
        private readonly IMapper mapper;

        public UniversityService(IUniversityRepository universityRepository, IMapper mapper)
        {
            this.universityRepository = universityRepository;
            this.mapper = mapper;
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

        public async Task<IEnumerable<UniversityDTO>> GetUniversities()
        {
            var universities = await universityRepository.GetAllAsync();
            return mapper.Map<IEnumerable<UniversityDTO>>(universities);
        }

        public async Task<bool> DeleteUniversityAsync(int universityId)
        {
            var university = await universityRepository.GetByIdAsync(universityId);
            if (university == null)
            {
                return false;
            }
            universityRepository.Remove(university);
            await universityRepository.SaveChangesAsync();
            return true;
        }
    }
}
