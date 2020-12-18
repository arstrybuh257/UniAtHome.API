using AutoMapper;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.DTOs.Course;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.DTOs.Timetable;
using UniAtHome.BLL.DTOs.University;
using UniAtHome.BLL.DTOs.UniversityRequest;
using UniAtHome.BLL.DTOs.Zoom;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Entities.Tests;
using UniAtHome.WebAPI.Models.Requests;
using UniAtHome.WebAPI.Models.Responses.Course;
using UniAtHome.WebAPI.Models.Responses.Lesson;
using UniAtHome.WebAPI.Models.Test;
using UniAtHome.WebAPI.Models.Timetable;
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
            CreateMap<Group, GroupDTO>();

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

            CreateMap<TimetableEntryDTO, Timetable>()
                .ForMember(
                    tt => tt.Date,
                    opt => opt.MapFrom(dto => dto.DateTime)
                );
            CreateMap<ZoomMeetingDTO, ZoomMeeting>();
            CreateMap<TimetableCreateRequest, TimetableEntryDTO>();
            CreateMap<TimetableEditRequest, TimetableEntryDTO>();
            CreateMap<TimetableDeleteRequest, TimetableEntryDeleteDTO>();

            CreateMap<TestCreateDTO, Test>();
            CreateMap<TestQuestionCreateDTO, TestQuestion>();
            CreateMap<TestAnswerVariantCreateDTO, TestAnswerVariant>();
            CreateMap<TestScheduleCreateDTO, TestSchedule>();
            CreateMap<TestEditDTO, Test>();
            CreateMap<TestQuestionEditDTO, TestQuestion>();
            CreateMap<TestAnswerVariantEditDTO, TestAnswerVariant>();
            CreateMap<TestScheduleEditDTO, TestSchedule>();
            CreateMap<Test, TestDTO>();
            CreateMap<TestQuestion, TestQuestionDTO>();
            CreateMap<TestAnswerVariant, TestAnswerVariantDTO>();
            CreateMap<TestSchedule, TestScheduleDTO>();
            CreateMap<TestAnswerRequest, AnswerSubmitDTO>();
            CreateMap<TestQuestion, TestTakingDTO.QuestionDTO>();
            CreateMap<TestAnswerVariant, TestTakingDTO.AnswerDTO>();
            CreateMap<Test, TestFullDTO>();
            CreateMap<TestQuestion, TestFullDTO.QuestionDTO>();
            CreateMap<TestAnswerVariant, TestFullDTO.AnswerDTO>();
        }
    }
}
