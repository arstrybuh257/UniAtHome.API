using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseByIdAsync(int id);

        Task<Course> GetCourseByWithLessonsIdAsync(int id);
    }
}
