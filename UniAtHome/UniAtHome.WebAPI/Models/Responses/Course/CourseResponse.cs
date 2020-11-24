using System;

namespace UniAtHome.WebAPI.Models.Responses.Course
{
    public class CourseResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public DateTimeOffset Added { get; set; }
    }
}
