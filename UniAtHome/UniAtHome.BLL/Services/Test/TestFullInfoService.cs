using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.DAL.Interfaces;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestFullInfoService : ITestFullInfoService
    {
        private readonly IRepository<TestEntity> testsRepository;

        private readonly IRepository<TestQuestion> questionsRepository;

        private readonly IRepository<TestAnswerVariant> answersRepository;

        private readonly IMapper mapper;

        public TestFullInfoService(
            IRepository<TestEntity> testsRepository,
            IRepository<TestQuestion> questionsRepository,
            IRepository<TestAnswerVariant> answersRepository,
            IMapper mapper)
        {
            this.testsRepository = testsRepository;
            this.questionsRepository = questionsRepository;
            this.answersRepository = answersRepository;
            this.mapper = mapper;
        }

        public async Task<TestFullDTO> GetTestFullInfoAsync(int testId)
        {
            TestEntity test = await testsRepository.GetByIdAsync(testId);
            if (test == null)
            {
                throw new NotFoundException("The test doesn't exist!");
            }

            var dto = mapper.Map<TestFullDTO>(test);
            var questions = await questionsRepository.Find(q => q.TestId == testId);
            dto.Questions = mapper.Map<IEnumerable<TestFullDTO.QuestionDTO>>(questions);
            foreach(var question in dto.Questions)
            {
                var answers = await answersRepository.Find(a => a.QuestionId == question.Id);
                question.Answers = mapper.Map<IEnumerable<TestFullDTO.AnswerDTO>>(answers);
            }

            return dto;
        }
    }
}
