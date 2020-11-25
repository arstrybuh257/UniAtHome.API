namespace UniAtHome.DAL.Entities
{
    public class ZoomUser
    {
        public string UserId { get; set; }

        public string Token { get; set; }

        public string RefreshToken { get; set; }

        public User User { get; set; }
    }
}
