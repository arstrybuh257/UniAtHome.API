namespace UniAtHome.WebAPI.Models.Course
{
    public class AddTeacherRequest
    {
        public int CourseId { get; set; }

        public string TeacherId { get; set; }
    }
}
