using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Course : BaseAuditableEntity
    {
        public Course()
        {
            CourseMembers = new List<CourseMember>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public List<CourseMember> CourseMembers { get; set; }
        public List<Lesson> Lessons { get; set; }

    }
}
