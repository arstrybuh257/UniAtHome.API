using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Interfaces.Collection;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.DAL.Interfaces;
using TestEntity = UniAtHome.DAL.Entities.Tests.Test;

namespace UniAtHome.BLL.Services.Test
{
    public class TestGenerationService : ITestGenerationService
    {
        private readonly IRepository<TestQuestion> questionsRepository;

        private readonly IRepository<TestAnswerVariant> answersRepository;

        private readonly ICollectionShuffler collectionShuffler;

        private readonly IMapper mapper;

        public TestGenerationService(
            IRepository<TestQuestion> questionsRepository,
            IRepository<TestAnswerVariant> answersRepository,
            ICollectionShuffler collectionShuffler,
            IMapper mapper)
        {
            this.questionsRepository = questionsRepository;
            this.answersRepository = answersRepository;
            this.collectionShuffler = collectionShuffler;
            this.mapper = mapper;
        }

        public async Task<TestTakingDTO> GenerateTestAsync(TestEntity test)
        {
            var testResponse = new TestTakingDTO
            {
                DurationMinutes = test.DurationMinutes,
                Id = test.Id,
                Name = test.Name,
                Questions = await GetQuestions(test)
            };
            return testResponse;
        }

        private async Task<IEnumerable<TestTakingDTO.QuestionDTO>> GetQuestions(TestEntity test)
        {
            var questions = await questionsRepository.Find(q => q.TestId == test.Id);
            var questionsDto = mapper
                .Map<IEnumerable<TestTakingDTO.QuestionDTO>>(questions);

            foreach (var question in questionsDto)
            {
                var answers = await answersRepository.Find(a => a.QuestionId == question.Id);
                var answersDto = mapper.Map<IEnumerable<TestTakingDTO.AnswerDTO>>(answers);
                question.Answers = answersDto;
            }

            if (test.ShuffleQuestions)
            {
                questionsDto = collectionShuffler.Shuffle(questionsDto);
            }
            if (test.ShuffleVariants)
            {
                foreach (var question in questionsDto)
                {
                    question.Answers = collectionShuffler.Shuffle(question.Answers);
                }
            }

            return questionsDto;
        }
    }
}
