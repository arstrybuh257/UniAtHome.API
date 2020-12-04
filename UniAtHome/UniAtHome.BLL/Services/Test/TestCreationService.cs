using AutoMapper;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Interfaces;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestCreationService : ITestCreationService
    {
        private readonly ICourseService courseService;

        private readonly IRepository<TestEntity> tests;

        private readonly IMapper mapper;

        public TestCreationService(
            ICourseService courseService,
            IRepository<TestEntity> tests,
            IMapper mapper)
        {
            this.courseService = courseService;
            this.tests = tests;
            this.mapper = mapper;
        }

        public async Task<int> CreateTestAsync(TestCreateDTO createDTO)
        {
            CourseDTO course = await courseService.GetCourseByIdAsync(createDTO.CourseId);
            if (course == null)
            {
                throw new BadRequestException("The course doesn't exist!");
            }

            TestEntity test = mapper.Map<TestEntity>(createDTO);

            ValidateTest(test);

            await tests.AddAsync(test);
            await tests.SaveChangesAsync();
            return test.Id;
        }

        private static void ValidateTest(TestEntity test)
        {
            if (test.DurationMinutes <= 0)
            {
                throw new BadRequestException("Test duration must be a non-zero positive value!");
            }
            if (test.AttemptsAllowed < 0)
            {
                throw new BadRequestException("Attempts count can't be negative!");
            }
        }

        public async Task DeleteTestAsync(int testId)
        {
            TestEntity test = await tests.GetByIdAsync(testId);
            if (test == null)
            {
                throw new NotFoundException("The test doesn't exist!");
            }
            tests.Remove(test);
            await tests.SaveChangesAsync();
        }

        public async Task EditTestAsync(TestEditDTO editDTO)
        {
            TestEntity test = await tests.GetByIdAsync(editDTO.Id);
            if (test == null)
            {
                throw new NotFoundException("The test doesn't exist!");
            }
            mapper.Map(editDTO, test);

            ValidateTest(test);

            tests.Update(test);
            await tests.SaveChangesAsync();
        }

        public async Task<TestDTO> GetTestAsync(int testId)
        {
            TestEntity test = await tests.GetByIdAsync(testId);
            if (test == null)
            {
                throw new NotFoundException("The test doesn't exist!");
            }

            var dto = mapper.Map<TestDTO>(test);
            return dto;
        }
    }
}
