using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;

namespace UniAtHome.BLL.Interfaces
{
    public interface ICourseService
    {
        CourseDTO GetCourseByIdAsync(int id);

        Task AddCourseAsync(CourseDTO course);
    }
}
