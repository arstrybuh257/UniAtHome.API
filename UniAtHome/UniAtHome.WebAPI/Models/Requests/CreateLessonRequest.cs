namespace UniAtHome.WebAPI.Models.Requests
{
    public class CreateLessonRequest
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string TypeOfLesson { get; set; }

        public int CourseId { get; set; }
    }
}
