namespace UniAtHome.BLL.DTOs.Auth
{
    public abstract class RegistrationDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
