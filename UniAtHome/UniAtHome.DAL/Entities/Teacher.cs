using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class Teacher
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public List<CourseMember> CourseMembers { get; set; }
    }
}
