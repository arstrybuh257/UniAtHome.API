using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.Group
{
    public class GroupCreateRequest
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string TeacherEmail { get; set; }

        [Required]
        public string GroupName { get; set; }
    }
}
