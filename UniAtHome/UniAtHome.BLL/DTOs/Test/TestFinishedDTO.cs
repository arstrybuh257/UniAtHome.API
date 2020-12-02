using System;

namespace UniAtHome.BLL.DTOs.Test
{
    public class TestFinishedDTO
    {
        public int TestId { get; set; }

        public int AttemptId { get; set; }

        public int CorrectAnswers { get; set; }

        public int TotalQuestions { get; set; }

        public float Mark { get; set; }

        public float MaxMark { get; set; }

        public DateTimeOffset Begin { get; set; }

        public DateTimeOffset End { get; set; }
    }
}
