using System.Collections.Generic;

namespace UniAtHome.DAL.Entities
{
    public class University : BaseEntity
    {
        public string Name { get; set; }

        public string ShortName { get; set; }

        public string Address { get; set; }

        public int Country { get; set; }

        public List<UniversityAdmin> UniversityAdmins { get; set; }

        public List<Student> Students { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Course> Courses { get; set; }
    }
}
