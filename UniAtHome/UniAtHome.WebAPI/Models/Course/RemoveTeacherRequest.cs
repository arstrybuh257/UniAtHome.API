namespace UniAtHome.WebAPI.Models.Course
{
    public class RemoveTeacherRequest
    {
        public int CourseId { get; set; }

        public string TeacherId { get; set; }
    }
}
