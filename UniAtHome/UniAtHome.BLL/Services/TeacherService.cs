using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Teacher;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> teacherRepository;

        private readonly IRepository<Course> courseRepository;

        private readonly IMapper mapper;

        public TeacherService(
            IRepository<Teacher> teacherRepository,
            IRepository<Course> courseRepository,
            IMapper mapper)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(TeachersCoursesRequest coursesRequest)
        {
            var teacherEmail = coursesRequest.TeacherEmail;

            var courses = await courseRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Teacher.User.Email == teacherEmail));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }
    }
}
