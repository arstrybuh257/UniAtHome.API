using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Course : BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TeacherId { get; set; }

        public List<Lesson> Lessons { get; set; }
        public User Teacher { get; set; }
    }
}
