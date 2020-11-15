using System;

namespace UniAtHome.BLL.DTOs.UniversityRequest
{
    public sealed class UniversityRequestDTO
    {
        public int Id { get; set; }

        public string UniversityName { get; set; }

        public string SubmitterFirstName { get; set; }

        public string SubmitterLastName { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime Submitted { get; set; }
    }
}
