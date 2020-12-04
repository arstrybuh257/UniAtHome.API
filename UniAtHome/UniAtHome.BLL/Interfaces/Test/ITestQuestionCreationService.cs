using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestQuestionCreationService
    {
        Task<int> CreateQuestionAsync(TestQuestionCreateDTO createDTO);

        Task DeleteQuestionAsync(int questionId);

        Task EditQuestionAsync(TestQuestionEditDTO editDTO);

        Task<TestQuestionDTO> GetQuestionAsync(int questionId);
    }
}
