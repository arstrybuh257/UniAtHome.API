namespace UniAtHome.DAL.Entities.Tests
{
    public class Test : BaseEntity
    {
        public string Name { get; set; }

        public int DurationMinutes { get; set; }

        public bool ShuffleQuestions { get; set; }

        public bool ShuffleVariants { get; set; }

        public int AttemptsAllowed { get; set; }

        public float MaxMark { get; set; }
    }
}
