using System;

namespace UniAtHome.BLL.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TeacherEmail { get; set; }

        public DateTime Added { get; set; }
    }
}
