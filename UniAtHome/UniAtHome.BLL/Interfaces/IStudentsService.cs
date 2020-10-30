using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Students;

namespace UniAtHome.BLL.Interfaces
{
    public interface IStudentsService
    {
        Task<StudentsCoursesResponse> GetStudentsCoursesAsync(StudentsCoursesRequest request);
    }
}