using AutoMapper;
using UniAtHome.BLL.DTOs;
using UniAtHome.DAL.Entities;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;

namespace UniAtHome.WebAPI.Configuration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap();

            CreateMap<CreateCourseRequest, CourseDTO>();
            CreateMap<CreateLessonRequest, LessonDTO>();

            CreateMap<CourseDTO, CourseResponseModel>();
        }
    }
}
