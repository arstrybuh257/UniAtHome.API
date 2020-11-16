using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.UniversityCreation
{
    public sealed class UniversityCreateRequestRequest
    {
        [Required]
        public string UniversityName { get; set; }

        [Required]
        public string UniversityShortName { get; set; }

        public string Address { get; set; }

        [Required]
        public int Country { get; set; }

        [Required]
        public string SubmitterFirstName { get; set; }

        [Required]
        public string SubmitterLastName { get; set; }

        [Required]
        public string Email { get; set; }

        public string Comment { get; set; }
    }
}
