namespace UniAtHome.WebAPI.Models.Group
{
    public class RemoveStudentFromGroupRequest
    {
        public int GroupId { get; set; }

        public string StudentEmail { get; set; }
    }
}
