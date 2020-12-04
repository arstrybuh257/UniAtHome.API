using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Test
{
    public class TestTakingDTO
    {
        public int AttemptId { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public int DurationMinutes { get; set; }

        public IEnumerable<QuestionDTO> Questions { get; set; }

        public class QuestionDTO
        {
            public int Id { get; set; }

            public string Text { get; set; }

            public bool Checkbox { get; set; }

            public IEnumerable<AnswerDTO> Answers { get; set; }
        }

        public class AnswerDTO
        {
            public int Id { get; set; }

            public string Text { get; set; }
        }
    }
}
