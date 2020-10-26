using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class CourseMember : BaseEntity
    {
        public string TeacherId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public Teacher Teacher { get; set; }
        public List<Group> Groups { get; set; }
    }
}
