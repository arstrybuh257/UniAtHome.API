namespace UniAtHome.DAL.Entities.Tests
{
    public class TestChosenAnswer
    {
        public int AttempId { get; set; }

        public int QuestionId { get; set; }

        public bool Correct { get; set; }

        public TestAttempt Attempt { get; set; }

        public TestQuestion Question { get; set; }

        public TestAnswerVariant AnswerVariant { get; set; }
    }
}
