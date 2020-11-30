namespace UniAtHome.DAL.Entities
{
    public class ZoomMeeting
    {
        public int GroupId { get; set; }

        public int LessonId { get; set; }

        public long ZoomId { get; set; }

        public string JoinUrl { get; set; }

        public string StartUrl { get; set; }
    }
}
