using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UniversityRequest;

namespace UniAtHome.BLL.Interfaces
{
    public interface IUniversityRegistrationService
    {
        Task<UniversityCreationResultDTO> CreateUniversityAsync(UniversityCreateRequestViewDTO createRequestDTO);
    }
}
