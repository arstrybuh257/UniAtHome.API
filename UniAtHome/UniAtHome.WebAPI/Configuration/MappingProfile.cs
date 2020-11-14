using AutoMapper;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.DTOs.University;
using UniAtHome.BLL.DTOs.UniversityRequest;
using UniAtHome.DAL.Entities;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;
using UniAtHome.WebAPI.Models.Responses.Lesson;
using UniAtHome.WebAPI.Models.UniversityCreation;
using UniAtHome.WebAPI.Models.Users;

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

            CreateMap<AdminRegistrationRequest, AdminRegistrationDTO>();
            CreateMap<UniversityAdminRegistrationRequest, UniversityAdminRegistrationDTO>();
            CreateMap<StudentRegistrationRequest, StudentRegistrationDTO>();
            CreateMap<TeacherRegistrationRequest, TeacherRegistrationDTO>();

            CreateMap<UniversitySubmitRequest, UniversityCreateDTO>();
            CreateMap<UniversityCreateRequest, UniversityRequestDTO>();

            CreateMap<University, UniversityDTO>();
        }
    }
}
