using System;

namespace UniAtHome.DAL.Entities
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTimeOffset Added { get; set; }

        public DateTimeOffset Modified { get; set; }
    }
}
