using System;

namespace UniAtHome.BLL.DTOs.Timetable
{
    public class TimetableEntryDTO
    {
        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime DateTime { get; set; }

        public bool WithZoomMeeting { get; set; }
    }
}
