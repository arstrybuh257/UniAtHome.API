using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;

namespace UniAtHome.BLL.Interfaces
{
    public interface IStudentsService
    {
        Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(string studentEmail);
    }
}