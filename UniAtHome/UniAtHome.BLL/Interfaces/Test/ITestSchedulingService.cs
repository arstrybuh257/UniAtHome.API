using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;

namespace UniAtHome.BLL.Interfaces.Test
{
    public interface ITestSchedulingService
    {
        Task<int> ScheduleTestAsync(TestScheduleCreateDTO createDTO);

        Task RemoveTestFromScheduleAsync(int scheduleId);

        Task EditTestScheduleAsync(TestScheduleEditDTO editDTO);

        Task<TestScheduleDTO> GetTestScheduleAsync(int scheduleId);
    }
}
