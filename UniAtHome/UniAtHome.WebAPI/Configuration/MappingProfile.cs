using AutoMapper;
using UniAtHome.BLL.DTOs;
using UniAtHome.DAL.Entities;
using UniAtHome.WebAPI.Models.Requests;

namespace UniAtHome.BLL.Util
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
            CreateMap<CreateCourseRequest, CourseDTO>();
            CreateMap<Lesson, LessonDTO>().ReverseMap();
        }
    }
}
