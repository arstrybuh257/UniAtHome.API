namespace UniAtHome.WebAPI.Models.Group
{
    public class GroupCreateRequest
    {
        public int CourseId { get; set; }

        public string TeacherId { get; set; }

        public string GroupName { get; set; }
    }
}
