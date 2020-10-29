using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Students;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IRepository<Student> studentRepository;

        private readonly IRepository<Course> coursesRepository;

        public StudentsService(IRepository<Student> studentRepository, IRepository<Course> coursesRepository)
        {
            this.studentRepository = studentRepository;
            this.coursesRepository = coursesRepository;
        }

        public async Task<StudentsCoursesResponse> GetStudentsCoursesAsync(StudentsCoursesRequest request)
        {
            var courses = await coursesRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Groups.Any(
                        group => group.StudentGroups.Any(
                            studentGroup => studentGroup.Student.User.Email == request.StudentEmail))));
            return new StudentsCoursesResponse
            {
                CoursesIds = courses.Select(course => course.Id)
            };
        }
    }
}
