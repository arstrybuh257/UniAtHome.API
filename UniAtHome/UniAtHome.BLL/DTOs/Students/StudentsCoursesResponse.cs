using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Students
{
    public sealed class StudentsCoursesResponse
    {
        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
