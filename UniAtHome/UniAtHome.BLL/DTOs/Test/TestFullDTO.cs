using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Test
{
    public class TestFullDTO
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public int DurationMinutes { get; set; }

        public bool ShuffleQuestions { get; set; }

        public bool ShuffleVariants { get; set; }

        public int AttemptsAllowed { get; set; }

        public IEnumerable<QuestionDTO> Questions { get; set; }

        public class QuestionDTO
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public bool Checkbox { get; set; }

            public float Weight { get; set; }

            public IEnumerable<AnswerDTO> Answers { get; set; }
        }

        public class AnswerDTO
        {
            public int Id { get; set; }

            public int QuestionId { get; set; }

            public string Text { get; set; }

            public bool IsCorrect { get; set; }
        }
    }
}
