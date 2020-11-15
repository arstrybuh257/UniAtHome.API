using System;

namespace UniAtHome.BLL.DTOs.UniversityRequest
{
    public sealed class UniversityCreateDTO
    {
        public string UniversityShortName { get; set; }
        public string UniversityName { get; set; }

        public string SubmitterFirstName { get; set; }

        public string SubmitterLastName { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}
