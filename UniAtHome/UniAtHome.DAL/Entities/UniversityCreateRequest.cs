using System;

namespace UniAtHome.DAL.Entities
{
    public class UniversityCreateRequest : BaseEntity
    {
        public string UniversityName { get; set; }

        public string UniversityShortName { get; set; }

        public string Address { get; set; }

        public int Country { get; set; }

        public string SubmitterFirstName { get; set; }

        public string SubmitterLastName { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public DateTime DateOfCreation { get; set; }
    }
}
