using System;

namespace UniAtHome.WebAPI.Models.Responses.Course
{
    public class CourseResponse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Added { get; set; }
    }
}
