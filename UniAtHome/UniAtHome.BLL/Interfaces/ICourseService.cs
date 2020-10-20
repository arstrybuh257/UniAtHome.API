using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;

namespace UniAtHome.BLL.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseByIdAsync(int id);

        Task AddCourseAsync(CourseDTO course);
    }
}
