using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;

namespace UniAtHome.BLL.Interfaces
{
    public interface IStudentsService
    {
        Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(string studentEmail);

        Task<RegistrationResponse> RegisterStudentAsync(RegistrationRequest request);
    }
}