using System;
using System.Collections.Generic;
using UniAtHome.WebAPI.Models.Responses.Lesson;

namespace UniAtHome.WebAPI.Models.Responses.Course
{
    public class CourseWithLessonsResponse
    {
        public CourseResponse Course { get; set; }

        public IEnumerable<LessonResponse> ListLessons { get; set; } = new List<LessonResponse>();
    }
}
