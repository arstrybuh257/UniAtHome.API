using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Lesson : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Timetable> Timetables { get; set; }
    }
}
