using System.Collections.Generic;

namespace UniAtHome.WebAPI.Models.Test
{
    public class TestAnswerRequest
    {
        public int AttempId { get; set; }

        public int QuestionId { get; set; }

        public IEnumerable<int> SelectedAnswers { get; set; }
    }
}
