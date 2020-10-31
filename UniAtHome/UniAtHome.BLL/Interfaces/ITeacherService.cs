using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;

namespace UniAtHome.BLL.Interfaces
{
    public interface ITeacherService
    {
        Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(string teacherEmail);

        Task<RegistrationResponse> RegisterTeacherAsync(RegistrationRequest request);
    }
}
