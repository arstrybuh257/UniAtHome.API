namespace UniAtHome.DAL.Entities
{
    public class UniversityAdmin
    {
        public string UserId { get; set; }

        public int UniversityId { get; set; }

        public User User { get; set; }

        public University University { get; set; }
    }
}
