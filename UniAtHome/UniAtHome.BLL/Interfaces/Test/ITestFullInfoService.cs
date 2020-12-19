using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestFullInfoService
    {
        Task<TestFullDTO> GetTestFullInfoAsync(int testId);
    }
}
