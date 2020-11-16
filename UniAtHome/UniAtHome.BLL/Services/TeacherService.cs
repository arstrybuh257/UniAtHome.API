using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.DTOs.Teacher;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Models.Filters;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository teacherRepository;

        private readonly IRepository<Course> courseRepository;

        private readonly IMapper mapper;

        public TeacherService(
            ITeacherRepository teacherRepository,
            IRepository<Course> courseRepository,
            IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<TeacherInfoDTO> GetTeacherInfoAsync(string id)
        {
            var teacher = await teacherRepository.GetByIdAsync(id);
            return new TeacherInfoDTO
            {
                Id = id,
                FirstName = teacher.User.FirstName,
                LastName = teacher.User.LastName,
                UniversityId = teacher.UniversityId
            };
        }

        public async Task<TeacherInfoDTO> GetTeacherInfoByEmailAsync(string email)
        {
            var teacher = (await teacherRepository
                .Find(t => t.User.Email == email)).First();
            return await GetTeacherInfoAsync(teacher.UserId); 
        }

        public async Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(CoursesFilter filter)
        {
            var teacherEmail = filter.UserEmail;

            var courses = await courseRepository.Find(
                course => course.CourseMembers.Any(members => members.Teacher.User.Email == teacherEmail) &&
                (filter.SearchText == null || course.Name.Contains(filter.SearchText)));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
    }
}
