using System;

namespace UniAtHome.WebAPI.Models.Timetable
{
    public class TimetableEditRequest
    {
        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public DateTime DateTime { get; set; }

        public bool WithZoomMeeting { get; set; }
    }
}
