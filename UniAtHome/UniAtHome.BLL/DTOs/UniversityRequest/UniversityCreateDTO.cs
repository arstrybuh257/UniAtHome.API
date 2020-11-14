namespace UniAtHome.BLL.DTOs.UniversityRequest
{
    public sealed class UniversityCreateDTO
    {
        public string UniversityName { get; set; }

        public string SubmitterFirstName { get; set; }

        public string SubmitterLastName { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }
    }
}
