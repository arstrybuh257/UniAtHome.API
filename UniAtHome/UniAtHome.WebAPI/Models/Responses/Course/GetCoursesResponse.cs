using System.Collections.Generic;
using UniAtHome.WebAPI.Models.Responses.Course;

namespace UniAtHome.WebAPI.Models.Responses
{
    public class GetCoursesResponse
    {
        public IEnumerable<CourseResponse> Courses { get; set; }
    }
}
