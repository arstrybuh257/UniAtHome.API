using System;

namespace UniAtHome.DAL.Entities
{
    public class BaseAuditableEntity : BaseEntity
    {
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }
    }
}
