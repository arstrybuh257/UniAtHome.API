using System;

namespace UniAtHome.BLL.DTOs.UniversityRequest
{
    public sealed class UniversityCreateRequestViewDTO
    {
        public int Id { get; set; }
        
        public string UniversityName { get; set; }

        public string UniversityShortName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string SubmitterFirstName { get; set; }

        public string SubmitterLastName { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public DateTimeOffset DateOfCreation { get; set; }
    }
}
