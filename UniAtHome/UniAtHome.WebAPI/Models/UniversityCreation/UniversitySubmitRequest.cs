using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.UniversityCreation
{
    public sealed class UniversitySubmitRequest
    {
        [Required]
        public string UniversityName { get; set; }

        [Required]
        public string SubmitterFirstName { get; set; }

        [Required]
        public string SubmitterLastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
