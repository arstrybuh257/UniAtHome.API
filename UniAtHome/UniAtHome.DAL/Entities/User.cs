using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace UniAtHome.DAL.Entities
{
    // TODO: Modify the given class according to the SRS
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
