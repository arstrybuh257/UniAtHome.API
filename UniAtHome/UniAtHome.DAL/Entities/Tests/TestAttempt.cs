using System;
using System.Collections.Generic;

namespace UniAtHome.DAL.Entities.Tests
{
    public class TestAttempt : BaseEntity
    {
        public string UserId { get; set; }

        public int TestId { get; set; }

        public DateTimeOffset BeginTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        public User User { get; set; }

        public Test Test { get; set; }

        public IList<TestAnsweredQuestion> AnsweredQuestions { get; set; }
    }
}
