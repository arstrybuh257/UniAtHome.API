using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.DTOs.Students;

namespace UniAtHome.BLL.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(StudentsCoursesRequest coursesRequest);

        Task<IEnumerable<GroupDTO>> GetStudentsGroupsAsync(string studentEmail);
    }
}