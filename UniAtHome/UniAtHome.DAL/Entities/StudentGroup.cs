namespace UniAtHome.DAL.Entities
{
    public class StudentGroup
    {
        public string StudentId { get; set; }
        public int GroupId { get; set; }
        public Student Student { get; set; }
        public Group Group { get; set; }
    }
}
