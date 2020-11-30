using AutoMapper;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Interfaces;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestCreationService : ITestCreationService
    {
        private readonly IRepository<TestSchedule> tests;

        private readonly IMapper mapper;

        public TestCreationService(IRepository<TestSchedule> tests, IMapper mapper)
        {
            this.tests = tests;
            this.mapper = mapper;
        }

        public async Task<int> CreateTestAsync(TestCreateDTO createDTO)
        {
            TestSchedule test = mapper.Map<TestSchedule>(createDTO);

            ValidateTest(test);

            await tests.AddAsync(test);
            await tests.SaveChangesAsync();
            return test.Id;
        }

        private static void ValidateTest(TestSchedule test)
        {
            if (test.DurationMinutes <= 0)
            {
                throw new BadRequestException("Test duration must be a non-zero positive value!");
            }
            if (test.AttemptsAllowed < 0)
            {
                throw new BadRequestException("Attemps count can't be negative!");
            }
        }

        public async Task DeleteTestAsync(int testId)
        {
            TestSchedule test = await tests.GetByIdAsync(testId);
            if (test == null)
            {
                throw new NotFoundException("The test doesn't exist!");
            }
            tests.Remove(test);
            await tests.SaveChangesAsync();
        }

        public async Task EditTestAsync(TestDTO editDTO)
        {
            TestSchedule test = await tests.GetByIdAsync(editDTO.Id);
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
            TestSchedule test = await tests.GetByIdAsync(testId);
            if (test == null)
            {
                throw new NotFoundException("The test doesn't exist!");
            }

            var dto = mapper.Map<TestDTO>(test);
            return dto;
        }
    }
}
