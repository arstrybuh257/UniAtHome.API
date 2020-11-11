using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository courseRepository;

        private readonly UserRepository userRepository;

        private readonly ITeacherRepository teacherRepository;

        private readonly IMapper mapper;

        public CourseService(
            ICourseRepository courseRepository,
            UserRepository userRepository,
            ITeacherRepository teacherRepository,
            IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
            this.teacherRepository = teacherRepository;
            this.mapper = mapper;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            return mapper.Map<CourseDTO>(course);
        }

        public async Task<CourseDTO> GetCourseWithLessonsByIdAsync(int id)
        {
            var course = await courseRepository.GetCourseWithLessonsByIdAsync(id);
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

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await courseRepository.GetByIdAsync(id);
            if (course != null)
            {
                courseRepository.Remove(course);
                await courseRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<IEnumerable<CourseDTO>> GetCoursesByNameAsync(string name)
        {
            var courses = await courseRepository.Find(
                course => EF.Functions.Like(course.Name, $"%{name}%"));
            return courses.Select(course => mapper.Map<CourseDTO>(course));
        }

        public async Task AddCourseMemberAsync(int courseId, string teacherId)
        {
            bool teacherIsAlreadyAdded = courseRepository
                .GetCourseTeachers(courseId)
                .Any(t => t.UserId == teacherId);
            if (teacherIsAlreadyAdded)
            {
                throw new BadRequestException("The teacher is already added!");
            }

            Teacher teacher = await teacherRepository.GetByIdAsync(teacherId);
            Course course = await courseRepository.GetByIdAsync(courseId);
            if (teacher.UniversityId != course.UniversityId)
            {
                throw new BadRequestException("Teacher of another university can't be added to this course!");
            }

            await courseRepository.AddCourseMemberAsync(courseId, teacherId);
            await courseRepository.SaveChangesAsync();
        }

        public async Task RemoveCourseMemberAsync(int courseId, string teacherId)
        {
            try
            {
                await courseRepository.RemoveCourseMemberAsync(courseId, teacherId);
                await courseRepository.SaveChangesAsync();
            }
            catch (InvalidOperationException)
            {
                throw new BadRequestException("Teacher doesn't belong to the course!");
            }
        }

        public IEnumerable<CourseMemberDTO> GetCourseMembers(int id)
        {
            return courseRepository.GetCourseTeachers(id)
                .Select(t => new CourseMemberDTO
                {
                    Id = t.UserId,
                    FirstName = t.User.FirstName,
                    LastName = t.User.LastName
                });
        }

        public IEnumerable<GroupDTO> GetCourseGroups(int id)
        {
            return courseRepository.GetCourseGroups(id)
                .Select(g => new GroupDTO
                {
                    Id = g.Id,
                    Name = g.Name
                });
        }
    }
}
