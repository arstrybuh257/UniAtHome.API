using System;

namespace UniAtHome.DAL.Entities
{
    public class Timetable
    {
        public DateTime Date { get; set; }
        public int GroupId { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public Group Group { get; set; }
    }
}
