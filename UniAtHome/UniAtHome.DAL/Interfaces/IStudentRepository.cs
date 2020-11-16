using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> GetByIdAsync(string id);
    }
}
