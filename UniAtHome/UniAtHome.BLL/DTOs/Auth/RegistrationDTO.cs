using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UniAtHome.BLL.DTOs.Auth
{
    public sealed class RegistrationDTO
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}
