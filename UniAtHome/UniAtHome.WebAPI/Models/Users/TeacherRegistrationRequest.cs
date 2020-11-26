namespace UniAtHome.WebAPI.Models.Users
{
    public sealed class TeacherRegistrationRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int UniversityId { get; set; }
    }
}
