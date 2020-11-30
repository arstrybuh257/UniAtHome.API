using System;

namespace UniAtHome.DAL.Entities.Tests
{
    public class TestSchedule
    {
        public int TestId { get; set; }

        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime BeginTime { get; set; }

        public Lesson Lesson { get; set; }

        public Group Group { get; set; }
    }

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
