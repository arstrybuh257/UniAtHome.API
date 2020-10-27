using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Group : BaseEntity
    {
        public List<StudentGroup> StudentGroups { get; set; }

        public int CourseMemberId { get; set; }

        public CourseMember CourseMember { get; set; }

        public List<Timetable> Timetables { get; set; }
    }
}
