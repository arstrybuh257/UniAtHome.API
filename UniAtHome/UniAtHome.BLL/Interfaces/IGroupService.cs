using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Group;

namespace UniAtHome.BLL.Interfaces
{
    public interface IGroupService
    {
        Task<int> AddGroupAsync(CreateGroupDTO dto);

        Task AddStudentToGroupAsync(int groupId, string studentId);

        Task DeleteGroupAsync(int groupId);

        Task<GroupInfoDTO> GetGroupInfoAsync(int groupId);

        Task RemoveStudentFromGroupAsync(int groupId, string studentId);
    }
}