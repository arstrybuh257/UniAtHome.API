using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.DTOs.Students;

namespace UniAtHome.BLL.Interfaces
{
    public interface IStudentsService
    {
        Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(StudentsCoursesRequest coursesRequest);

        Task<RegistrationResponse> RegisterStudentAsync(RegistrationRequest request);
    }
}