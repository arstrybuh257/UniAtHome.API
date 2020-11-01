using AutoMapper;
using UniAtHome.BLL.DTOs;
using UniAtHome.DAL.Entities;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;
using UniAtHome.WebAPI.Models.Responses.Lesson;

namespace UniAtHome.WebAPI.Configuration
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<Lesson, LessonDTO>().ReverseMap();

            CreateMap<CreateCourseRequest, CourseDTO>().ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Title));
            CreateMap<CreateLessonRequest, LessonDTO>();

            CreateMap<CourseDTO, CourseResponse>().ForMember(
                dest => dest.Title,
                opt => opt.MapFrom(src => src.Name));
            CreateMap<LessonDTO, LessonResponse>();
        }
    }
}
