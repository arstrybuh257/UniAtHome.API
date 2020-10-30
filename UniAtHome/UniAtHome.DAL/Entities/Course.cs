using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Course : BaseAuditableEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<CourseMember> CourseMembers { get; set; }
    }
}
