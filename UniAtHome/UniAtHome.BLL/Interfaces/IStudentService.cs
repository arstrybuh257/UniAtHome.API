using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.Models.Filters;

namespace UniAtHome.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(CoursesFilter filter);
    }
}