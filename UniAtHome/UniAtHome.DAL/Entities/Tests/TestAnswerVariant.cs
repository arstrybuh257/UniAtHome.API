namespace UniAtHome.DAL.Entities.Tests
{
    public class TestAnswerVariant : BaseEntity
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsCorrect { get; set; }

        public TestQuestion Question { get; set; }
    }
}
