using System.ComponentModel.DataAnnotations;

namespace UniAtHome.WebAPI.Models.UsersRequests
{
    public sealed class LoginRequest
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
