namespace UniAtHome.DAL.Entities.Tests
{
    public class TestAnsweredQuestion
    {
        public int AttemptId { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }

        public TestAttempt Attempt { get; set; }

        public TestQuestion Question { get; set; }

        public TestAnswerVariant AnswerVariant { get; set; }
    }
}
