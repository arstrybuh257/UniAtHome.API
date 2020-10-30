using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IRepository<Student> studentRepository;

        private readonly IRepository<Course> coursesRepository;

        private readonly IMapper mapper;

        public StudentsService(IRepository<Student> studentRepository, IRepository<Course> coursesRepository, IMapper mapper)
        {
            this.studentRepository = studentRepository;
            this.coursesRepository = coursesRepository;
        }

        public async Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(string studentEmail)
        {
            var courses = await coursesRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Groups.Any(
                        group => group.StudentGroups.Any(
                            studentGroup => studentGroup.Student.User.Email == studentEmail))));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
    }
}
