using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task AddStudentToGroupAsync(int groupId, string studentId);

        Task RemoveStudentFromGroupAsync(int groupId, string studentId);

        Task<bool> IsStudentInGroupAsync(int groupId, string studentId);

        IEnumerable<Student> GetGroupStudents(int groupId);
    }
}
