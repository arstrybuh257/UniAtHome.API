﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Course;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;
using UniAtHome.WebAPI.Models.Responses.Lesson;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService courseService;

        private readonly IMapper mapper;

        private readonly IUniversityService universityService;

        private readonly ITeacherService teacherService;

        public CourseController(
            ICourseService courseService, 
            IMapper mapper, 
            IUniversityService universityService, 
            ITeacherService teacherService)
        {
            this.courseService = courseService;
            this.mapper = mapper;
            this.universityService = universityService;
            this.teacherService = teacherService;
        }

        // GET: api/Course/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await courseService.GetCourseByIdAsync(id);
            if (course != null)
            {
                return Ok(course);
            }

            return BadRequest();
        }

        // GET: api/Course/5
        [HttpGet("{id}/Lessons")]
        public async Task<IActionResult> GetCourseWithLessonsById(int id)
        {
            var course = await courseService.GetCourseWithLessonsByIdAsync(id);
            if (course != null)
            {
                CourseWithLessonsResponse response = new CourseWithLessonsResponse
                {
                    Course = mapper.Map<CourseResponse>(course),
                    ListLessons = mapper.Map<IEnumerable<LessonResponse>>(course.Lessons)
                };

                return Ok(response);
            }

            return BadRequest();
        }

        // POST: api/Course
        [HttpPost]
        [Authorize(Roles = RoleName.TEACHER)]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            if (request != null && ModelState.IsValid)
            {
                var courseDto = mapper.Map<CreateCourseRequest, CourseDTO>(request);
                courseDto.TeacherEmail = User.Identity.Name;
                courseDto.UniversityId = (await teacherService
                    .GetTeacherInfoByEmailAsync(User.Identity.Name)).UniversityId;
                await courseService.AddCourseAsync(courseDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = RoleName.TEACHER)]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            //temporary
            if (await courseService.DeleteCourseAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("addTeacher")]
        public async Task<IActionResult> AddTeacherAsync([FromBody] AddTeacherRequest request)
        {
            CourseDTO course = await courseService.GetCourseByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new BadRequestException("Course doesn't exist");
            }
            if (!await User.IsUniversityTeacherOrHigherAsync(course.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights to access the course!");
            }

            await courseService.AddCourseMemberAsync(request.CourseId, request.TeacherId);
            return Ok();
        }

        [HttpPost("removeTeacher")]
        public async Task<IActionResult> RemoveTeacherAsync([FromBody] RemoveTeacherRequest request)
        {
            CourseDTO course = await courseService.GetCourseByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new BadRequestException("Course doesn't exist");
            }
            if (!await User.IsUniversityTeacherOrHigherAsync(course.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights to access the course!");
            }

            await courseService.RemoveCourseMemberAsync(request.CourseId, request.TeacherId);
            return Ok();
        }

        [HttpGet("{id}/teachers")]
        public IActionResult GetAllTeachers(int id)
        {
            IEnumerable<CourseMemberDTO> teachers = courseService.GetCourseMembers(id);
            return Ok(teachers.Select(t => new
            {
                t.Id,
                t.FirstName,
                t.LastName
            }));
        }
    }
}