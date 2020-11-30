using System;

namespace UniAtHome.DAL.Entities.Tests
{
    public class TestAttempt : BaseEntity
    {
        public string UserId { get; set; }

        public int TestId { get; set; }

        public DateTime BeginTime { get; set; }

        public DateTime? EndTime { get; set; }

        public User User { get; set; }

        public Test Test { get; set; }
    }
}
