using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestTakingService
    {
        Task<TestTakingDTO> StartTestAsync(int id, string email);

        Task SubmitAnswerAsync(AnswerSubmitDTO submit);

        Task<TestFinishedDTO> FinishAsync(int attemptId, string email);

        Task<IEnumerable<TestFinishedDTO>> GetAllFinishedAttemptsAsync(int testId, string email);
    }
}
