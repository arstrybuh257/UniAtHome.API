using AutoMapper;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services.Test
{
    public class TestQuestionCreationService : ITestQuestionCreationService
    {
        private readonly IRepository<TestQuestion> questions;

        private readonly ITestCreationService testCreationService;

        private readonly IMapper mapper;

        public TestQuestionCreationService(
            IRepository<TestQuestion> questions,
            ITestCreationService testCreationService,
            IMapper mapper)
        {
            this.questions = questions;
            this.testCreationService = testCreationService;
            this.mapper = mapper;
        }

        private static void ValidateQuestion(TestQuestion question)
        {
            if (question.Weight < 0)
            {
                throw new BadRequestException("Question weight must be a positive value!");
            }
        }

        public async Task<int> CreateQuestionAsync(TestQuestionCreateDTO createDTO)
        {
            TestDTO test = await testCreationService.GetTestAsync(createDTO.TestId);
            if (test == null)
            {
                throw new BadRequestException("The test doesn't exist!");
            }
            TestQuestion question = mapper.Map<TestQuestion>(createDTO);

            ValidateQuestion(question);

            await questions.AddAsync(question);
            await questions.SaveChangesAsync();
            return question.Id;
        }

        public async Task DeleteQuestionAsync(int questionId)
        {
            TestQuestion question = await questions.GetByIdAsync(questionId);
            if (question == null)
            {
                throw new NotFoundException("The question doesn't exist!");
            }
            questions.Remove(question);
            await questions.SaveChangesAsync();
        }

        public async Task EditQuestionAsync(TestQuestionEditDTO editDTO)
        {
            TestQuestion question = await questions.GetByIdAsync(editDTO.Id);
            if (question == null)
            {
                throw new NotFoundException("The question doesn't exist!");
            }
            mapper.Map(editDTO, question);

            ValidateQuestion(question);

            questions.Update(question);
            await questions.SaveChangesAsync();
        }

        public async Task<TestQuestionDTO> GetQuestionAsync(int questionId)
        {
            TestQuestion question = await questions.GetByIdAsync(questionId);
            if (question == null)
            {
                throw new NotFoundException("The question doesn't exist!");
            }

            var dto = mapper.Map<TestQuestionDTO>(question);
            return dto;
        }
    }
}
