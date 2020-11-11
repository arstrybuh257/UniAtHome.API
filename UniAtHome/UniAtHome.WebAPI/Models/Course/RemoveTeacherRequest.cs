using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.Course
{
    public class RemoveTeacherRequest
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string TeacherId { get; set; }
    }
}
