namespace UniAtHome.WebAPI.Models.Responses.Lesson
{
    public class LessonResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        //TODO: Create enum for stroing lesson types
        public int TypeLesson { get; set; } = 0;

        public int CourseId { get; set; }
    }
}
