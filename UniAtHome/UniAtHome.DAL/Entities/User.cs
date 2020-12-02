using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using UniAtHome.DAL.Entities.Tests;

namespace UniAtHome.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public List<RefreshToken> RefreshTokens { get; set; }

        public List<TestAttempt> TestAttempts { get; set; }
    }
}
