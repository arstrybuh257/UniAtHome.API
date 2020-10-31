using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public class CourseService: ICourseService
    {
        private readonly IRepository<Course> courseRepository;
        private readonly UserRepository userRepository;
        private readonly IMapper mapper;

        public CourseService(IRepository<Course> courseRepository, IMapper mapper,  UserRepository userRepository)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            return mapper.Map<CourseDTO>(course);
        }

        public async Task AddCourseAsync(CourseDTO courseDto)
        {
            var course = mapper.Map<Course>(courseDto);
            var teacherId = (await userRepository.FindByEmailAsync(courseDto.TeacherEmail)).Id;
            course.CourseMembers.Add(new CourseMember() { TeacherId = teacherId });
            await courseRepository.AddAsync(course);
            await courseRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByNameAsync(string name)
        {
            var courses = await courseRepository.Find(
                course => EF.Functions.Like(course.Name, $"%{name}%"));
            return courses.Select(course => mapper.Map<CourseDTO>(course));
        }
    }
}
