using System.ComponentModel.DataAnnotations;

namespace UniAtHome.DAL.Entities
{
    public class Lesson : BaseAuditableEntity
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
