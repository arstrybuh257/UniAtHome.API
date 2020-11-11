namespace UniAtHome.BLL.DTOs.Group
{
    public class RemoveStudentFromGroupRequest
    {
        public int GroupId { get; set; }

        public string StudentEmail { get; set; }
    }
}
