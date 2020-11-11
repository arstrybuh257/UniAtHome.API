using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.Course
{
    public class AddTeacherRequest
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string TeacherEmail { get; set; }
    }
}
