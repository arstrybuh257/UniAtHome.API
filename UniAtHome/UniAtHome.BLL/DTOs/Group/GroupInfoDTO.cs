using System.Collections.Generic;

namespace UniAtHome.BLL.DTOs.Group
{
    public class GroupInfoDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
