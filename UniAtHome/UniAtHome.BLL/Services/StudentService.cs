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
        private readonly IRepository<Course> coursesRepository;

        private readonly IRepository<Group> groupsRepository;

        private readonly IMapper mapper;

        public StudentService(
            IRepository<Course> coursesRepository,
            IRepository<Group> groupsRepository,
            IMapper mapper)
        {
            this.coursesRepository = coursesRepository;
            this.groupsRepository = groupsRepository;
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

        public async Task<IEnumerable<GroupDTO>> GetStudentsGroupsAsync(string studentEmail)
        {
            var groups = await groupsRepository.Find(
                gr => gr.StudentGroups.Any(
                    st => st.Student.User.Email == studentEmail)
                );
            return mapper.Map<IEnumerable<GroupDTO>>(groups);
        }
    }
}
