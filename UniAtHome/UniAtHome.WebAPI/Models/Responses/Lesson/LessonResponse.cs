namespace UniAtHome.WebAPI.Models.Responses.Lesson
{
    public class LessonResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int CourseId { get; set; }
    }
}
