using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.Requests
{
    public class CreateCourseRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
