using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestCreationService
    {
        Task<int> CreateTestAsync(TestCreateDTO createDTO);

        Task DeleteTestAsync(int testId);

        Task EditTestAsync(TestEditDTO editDTO);

        Task<TestDTO> GetTestAsync(int testId);
    }
}
