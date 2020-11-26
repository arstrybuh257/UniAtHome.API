using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.DTOs.Students;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> studentRepository;

        private readonly IRepository<Course> coursesRepository;

        private readonly IMapper mapper;

        public StudentService(
            IRepository<Student> studentRepository, 
            IRepository<Course> coursesRepository, 
            IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.coursesRepository = coursesRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(StudentsCoursesRequest coursesRequest)
        {
            var studentEmail = coursesRequest.StudentEmail;

            var courses = await coursesRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Groups.Any(
                        group => group.StudentGroups.Any(
                            studentGroup => studentGroup.Student.User.Email == studentEmail))));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
    }
}
