using System;

namespace UniAtHome.BLL.DTOs.Timetable
{
    public class TimetableDTO
    {
        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTimeOffset DateTime { get; set; }

        public string ZoomUrl { get; set; }
    }
}
