using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestAnswerCreationService
    {
        Task<int> CreateAnswerVariantAsync(TestAnswerVariantCreateDTO createDTO);

        Task DeleteAnswerVariantAsync(int answerId);

        Task EditAnswerVariantAsync(TestAnswerVariantEditDTO editDTO);

        Task<TestAnswerVariantDTO> GetAnswerVariantAsync(int answerId);
    }
}
