using System;

namespace UniAtHome.BLL.DTOs.Test
{
    public class TestScheduleEditDTO
    {
        public int Id { get; set; }

        public DateTimeOffset BeginTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

    }
}
