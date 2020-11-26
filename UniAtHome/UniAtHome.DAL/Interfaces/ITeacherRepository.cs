using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<Teacher> GetByIdAsync(string id);

        Task<Teacher> GetByEmailAsync(string emaiil);
    }
}
