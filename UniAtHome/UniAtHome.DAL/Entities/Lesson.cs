using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Lesson : BaseAuditableEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public List<Timetable> Timetables { get; set; }

        public List<Tests.Test> Tests { get; set; } 
    }
}
