using System.Collections.Generic;

namespace UniAtHome.DAL.Entities.Tests
{
    public class TestQuestion : BaseEntity
    {
        public int TestId { get; set; }

        public string Text { get; set; }

        public bool Checkbox { get; set; }

        public float Weight { get; set; }

        public Test Test { get; set; }

        public List<TestAnswerVariant> Answers { get; set; }

        public List<TestAnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
