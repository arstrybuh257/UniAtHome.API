using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.DTOs.Timetable;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Interfaces.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestSchedulingService
    {
        private readonly ILessonService lessonService;

        private readonly ITimetableService timetableService;

        private readonly ITestCreationService testCreation;

        public async Task ScheduleTest(TestScheduleDTO test)
        {
            TestDTO testDto = await testCreation.GetTestAsync(test.TestId);

            TimetableDTO timetable = await timetableService.GetTimetableAsync(test.GroupId, test.LessonId);
            if (timetable == null)
            {
                throw new BadRequestException("Timetable entry doesn't exist!");
            }
            if (test.BeginTime < timetable.DateTime)
            {
                throw new BadRequestException("Can't begin test before lesson start!");
            }

        }
    }
}
