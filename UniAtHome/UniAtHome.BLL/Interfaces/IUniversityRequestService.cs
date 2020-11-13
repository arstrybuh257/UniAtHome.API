using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UniversityRequest;

namespace UniAtHome.BLL.Interfaces
{
    public interface IUniversityRequestService
    {
        Task AddRequestAsync(UniversityCreateDTO creationInfo);

        Task<IEnumerable<UniversityRequestDTO>> GetAllRequestsAsync();

        Task ApproveRequestAsync(int id);

        Task RejectRequestAsync(int id);
    }
}
