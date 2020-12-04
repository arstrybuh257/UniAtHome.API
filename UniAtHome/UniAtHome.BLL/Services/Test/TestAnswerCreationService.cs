using AutoMapper;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services.Test
{
    public class TestAnswerCreationService : ITestAnswerCreationService
    {
        private readonly IRepository<TestAnswerVariant> answers;

        private readonly ITestQuestionCreationService questionCreationService;

        private readonly IMapper mapper;

        public TestAnswerCreationService(
            IRepository<TestAnswerVariant> answers,
            ITestQuestionCreationService questionCreationService,
            IMapper mapper)
        {
            this.answers = answers;
            this.questionCreationService = questionCreationService;
            this.mapper = mapper;
        }

        public async Task<int> CreateAnswerVariantAsync(TestAnswerVariantCreateDTO createDTO)
        {
            TestQuestionDTO question = await questionCreationService.GetQuestionAsync(createDTO.QuestionId);
            if (question == null)
            {
                throw new BadRequestException("The test doesn't exist!");
            }
            TestAnswerVariant answer = mapper.Map<TestAnswerVariant>(createDTO);

            await answers.AddAsync(answer);
            await answers.SaveChangesAsync();
            return answer.Id;
        }

        public async Task DeleteAnswerVariantAsync(int answerId)
        {
            TestAnswerVariant answer = await answers.GetByIdAsync(answerId);
            if (answer == null)
            {
                throw new NotFoundException("The answer doesn't exist!");
            }
            answers.Remove(answer);
            await answers.SaveChangesAsync();
        }

        public async Task EditAnswerVariantAsync(TestAnswerVariantEditDTO editDTO)
        {
            TestAnswerVariant answer = await answers.GetByIdAsync(editDTO.Id);
            if (answer == null)
            {
                throw new NotFoundException("The answer doesn't exist!");
            }

            mapper.Map(editDTO, answer);

            answers.Update(answer);
            await answers.SaveChangesAsync();
        }

        public async Task<TestAnswerVariantDTO> GetAnswerVariantAsync(int answerId)
        {
            TestAnswerVariant answer = await answers.GetByIdAsync(answerId);
            if (answer == null)
            {
                throw new NotFoundException("The answer doesn't exist!");
            }

            var dto = mapper.Map<TestAnswerVariantDTO>(answer);
            return dto;
        }
    }
}
