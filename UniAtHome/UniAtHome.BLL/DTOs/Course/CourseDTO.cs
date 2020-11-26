using System;
using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Course
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TeacherEmail { get; set; }

        public DateTimeOffset Added { get; set; }

        public string ImagePath { get; set; }

        public int UniversityId { get; set; }

        public IEnumerable<LessonDTO> Lessons { get; set; } = new List<LessonDTO>();
    }
}
