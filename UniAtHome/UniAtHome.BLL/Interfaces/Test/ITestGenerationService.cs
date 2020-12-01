using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestGenerationService
    {
        Task<TestTakingDTO> GenerateTestAsync(TestEntity test);
    }
}
