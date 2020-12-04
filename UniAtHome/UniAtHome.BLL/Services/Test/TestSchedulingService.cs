using AutoMapper;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.DTOs.Timetable;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services.Test
{
    public class TestSchedulingService : ITestSchedulingService
    {
        private readonly ITimetableService timetableService;

        private readonly ITestCreationService testCreation;

        private readonly IRepository<TestSchedule> schedules;

        private readonly IMapper mapper;

        public TestSchedulingService(
            ITimetableService timetableService,
            ITestCreationService testCreation,
            IRepository<TestSchedule> schedules,
            IMapper mapper)
        {
            this.timetableService = timetableService;
            this.testCreation = testCreation;
            this.schedules = schedules;
            this.mapper = mapper;
        }

        public async Task<int> ScheduleTestAsync(TestScheduleCreateDTO createDTO)
        {
            TestSchedule schedule = mapper.Map<TestSchedule>(createDTO);

            await ValidateSchedule(schedule);

            await schedules.AddAsync(schedule);
            await schedules.SaveChangesAsync();
            return schedule.Id;
        }

        private async Task ValidateSchedule(TestSchedule schedule)
        {
            TestDTO testDto = await testCreation.GetTestAsync(schedule.TestId);
            if (testDto == null)
            {
                throw new BadRequestException("The test doesn't exist!");
            }
            TimetableDTO timetable = await timetableService.GetTimetableAsync(
                schedule.GroupId,
                schedule.LessonId);
            if (timetable == null)
            {
                throw new BadRequestException("Timetable entry doesn't exist!");
            }

            if (schedule.BeginTime < timetable.DateTime)
            {
                throw new BadRequestException("Can't begin test before lesson start!");
            }
            if (schedule.BeginTime >= schedule.EndTime)
            {
                throw new BadRequestException("Test can't end before it begins");
            }
        }

        public async Task EditTestScheduleAsync(TestScheduleEditDTO editDTO)
        {
            TestSchedule schedule = await schedules.GetByIdAsync(editDTO.Id);
            if (schedule == null)
            {
                throw new NotFoundException("The schedule for the test doesn't exist!");
            }
            mapper.Map(editDTO, schedule);

            await ValidateSchedule(schedule);

            schedules.Update(schedule);
            await schedules.SaveChangesAsync();
        }

        public async Task<TestScheduleDTO> GetTestScheduleAsync(int scheduleId)
        {
            TestSchedule schedule = await schedules.GetByIdAsync(scheduleId);
            if (schedule == null)
            {
                throw new NotFoundException("The schedule for the test doesn't exist!");
            }

            var dto = mapper.Map<TestScheduleDTO>(schedule);
            return dto;
        }

        public async Task RemoveTestFromScheduleAsync(int scheduleId)
        {
            TestSchedule schedule = await schedules.GetByIdAsync(scheduleId);
            if (schedule == null)
            {
                throw new NotFoundException("The schedule for the test doesn't exist!");
            }
            schedules.Remove(schedule);
            await schedules.SaveChangesAsync();
        }
    }
}
