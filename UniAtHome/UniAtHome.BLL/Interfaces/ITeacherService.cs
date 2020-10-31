using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.DTOs.Teacher;

namespace UniAtHome.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(TeachersCoursesRequest coursesRequest);

        Task<RegistrationResponse> RegisterTeacherAsync(RegistrationRequest request);
    }
}
