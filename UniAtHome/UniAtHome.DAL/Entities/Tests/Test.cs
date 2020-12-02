using System.Collections.Generic;

namespace UniAtHome.DAL.Entities.Tests
{
    public class Test : BaseEntity
    {
        public int CourseId { get; set; }

        public string Name { get; set; }

        public int DurationMinutes { get; set; }

        public bool ShuffleQuestions { get; set; }

        public bool ShuffleVariants { get; set; }

        public int AttemptsAllowed { get; set; }

        public float MaxMark { get; set; }

        public Course Course { get; set; }

        public List<TestQuestion> Questions { get; set; }

        public List<TestAttempt> TestAttempts { get; set; }
    }
}
