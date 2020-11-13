using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.DTOs.UniversityRequest;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class UniversityRegistrationService : IUniversityRegistrationService
    {
        private readonly IUniversityRepository universityRepository;

        private readonly IAuthService authService;

        private readonly IPasswordGenerator passwordGenerator;

        public UniversityRegistrationService(
            IUniversityRepository universityRepository, 
            IAuthService authService, 
            IPasswordGenerator passwordGenerator)
        {
            this.universityRepository = universityRepository;
            this.authService = authService;
            this.passwordGenerator = passwordGenerator;
        }

        public async Task<UniversityCreationResultDTO> CreateUniversityAsync(UniversityRequestDTO createRequestDTO)
        {
            var university = new University
            {
                Name = createRequestDTO.UniversityName,
            };
            await universityRepository.AddAsync(university);

            UniversityAdminRegistrationDTO adminRegisterRequest = new UniversityAdminRegistrationDTO
            {
                FirstName = createRequestDTO.SubmitterFirstName,
                LastName = createRequestDTO.SubmitterLastName,
                Email = createRequestDTO.Email,
                Password = passwordGenerator.GeneratePassword(),
                UniversityId = university.Id
            };
            await authService.RegisterUniversityAdminAsync(adminRegisterRequest);

            await universityRepository.SaveChangesAsync();

            return new UniversityCreationResultDTO
            {
                UniversityId = university.Id,
                UniversityName = university.Name,
                AdminEmail = adminRegisterRequest.Email,
                AdminPassword = adminRegisterRequest.Password
            };
        }
    }
}
