using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.DAL.Entities;

namespace UniAtHome.DAL.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<Course> GetCourseByIdAsync(int id);

        Task<Course> GetCourseWithLessonsByIdAsync(int id);

        Task AddCourseMemberAsync(int courseId, string teacherId);

        Task RemoveCourseMemberAsync(int courseId, string teacherId);

        IEnumerable<Teacher> GetCourseTeachers(int courseId);

        IEnumerable<Group> GetCourseGroups(int courseId);

        Task<int?> GetCourseMemberIdAsync(int courseId, string teacherId);
    }
}
