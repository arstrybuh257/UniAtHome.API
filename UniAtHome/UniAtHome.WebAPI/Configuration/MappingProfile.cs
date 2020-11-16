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
    public class MappingProfile : Profile
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

            CreateMap<UniversityCreateRequestRequest, UniversityCreateRequestDTO>();
            CreateMap<UniversityCreateRequestDTO, UniversityCreateRequest>();
            CreateMap<UniversityCreateRequest, UniversityCreateRequestViewDTO>();
            CreateMap<UniversityCreateRequestViewDTO, University>()
                .ForMember(
                    university => university.Name,
                    opt => opt.MapFrom(request => request.UniversityName))
                .ForMember(
                    university => university.ShortName,
                    opt => opt.MapFrom(request => request.UniversityShortName));
            CreateMap<UniversityCreateRequestViewDTO, UniversityCreateRequestModel>();

            CreateMap<University, UniversityDTO>();
        }
    }
}
