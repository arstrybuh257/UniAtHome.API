using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Test
{
    public class AnswerSubmitDTO
    {
        public int AttemptId { get; set; }

        public string Email { get; set; }

        public int QuestionId { get; set; }

        public IEnumerable<int> SelectedAnswers { get; set; }
    }
}
