using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UniAtHome.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Course> Courses { get; set; }
    }
}
