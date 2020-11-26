using System;

namespace UniAtHome.DAL.Entities
{
    public class RefreshToken : BaseEntity
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public DateTimeOffset ExpirationDate { get; set; }

        public User User { get; set; }
    }
}
