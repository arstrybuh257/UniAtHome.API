using System;

namespace UniAtHome.BLL.DTOs.Test
{
    public class TestScheduleDTO
    {
        public int Id { get; set; }

        public int TestId { get; set; }

        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime BeginTime { get; set; }
    }
}
