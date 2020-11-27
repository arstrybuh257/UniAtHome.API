using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Timetable;
using UniAtHome.BLL.DTOs.Zoom;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Services.Zoom;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class TimetableService
    {
        private readonly IRepository<Lesson> lessonsRepository;

        private readonly IGroupRepository groupRepository;

        private readonly IRepository<Timetable> timetablesRepository;

        private readonly IRepository<ZoomMeeting> zoomMeetingRepository;

        private readonly ZoomMeetingService zoomMeetingService;

        private readonly ICourseService courseService;

        private readonly IMapper mapper;

        public TimetableService(
            IRepository<Lesson> lessonsRepository, 
            IGroupRepository groupRepository, 
            IRepository<Timetable> timetablesRepository, 
            IRepository<ZoomMeeting> zoomMeetingRepository, 
            ZoomMeetingService zoomMeetingService, 
            ICourseService courseService, 
            IMapper mapper)
        {
            this.lessonsRepository = lessonsRepository;
            this.groupRepository = groupRepository;
            this.timetablesRepository = timetablesRepository;
            this.zoomMeetingRepository = zoomMeetingRepository;
            this.zoomMeetingService = zoomMeetingService;
            this.courseService = courseService;
            this.mapper = mapper;
        }

        public async Task CreateTimetableEntryAsync(TimetableEntryDTO timetableDto, string creatorEmail)
        {
            await ValidateTimetableCreation(timetableDto);

            var newTimetable = mapper.Map<Timetable>(timetableDto);
            await timetablesRepository.AddAsync(newTimetable);

            if (timetableDto.WithZoomMeeting)
            {
                var meetingRecord = await CreateZoomMeetingForTimetable(newTimetable, creatorEmail);
                await zoomMeetingRepository.AddAsync(meetingRecord);
            }

            await timetablesRepository.SaveChangesAsync();
        }

        private async Task ValidateTimetableCreation(TimetableEntryDTO timetableDto)
        {
            Group group = await groupRepository.GetByIdAsync(timetableDto.GroupId);
            if (group == null)
            {
                throw new BadRequestException("The group does not exist!");
            }
            Lesson lesson = await lessonsRepository.GetByIdAsync(timetableDto.LessonId);
            if (lesson == null)
            {
                throw new BadRequestException("The lesson does not exist!");
            }
            Timetable timetable = await timetablesRepository.GetSingleOrDefaultAsync(
                    tt => tt.GroupId == timetableDto.GroupId && tt.LessonId == timetableDto.LessonId);
            if (timetable != null)
            {
                throw new BadRequestException("The timetable entry already exists!");
            }
        }

        private async Task<ZoomMeeting> CreateZoomMeetingForTimetable(Timetable timetable, string creatorEmail)
        {
            Lesson lesson = await lessonsRepository.GetByIdAsync(timetable.LessonId);

            var courseTeachersButCreator = courseService.GetCourseMembers(lesson.CourseId)
                .Select(t => t.Email)
                .Except(new[] { creatorEmail });

            ZoomMeetingDTO createdMeeting = await zoomMeetingService
                .CreateMeetingAsync(new ZoomMeetingCreateDTO
                {
                    Type = ZoomMeetingType.Scheduled,
                    Topic = lesson.Title,
                    Agenda = lesson.Description,
                    Settings = new ZoomMeetingSettingsDTO
                    {
                        AlternativeHosts = string.Join(',', courseTeachersButCreator),
                        JoinBeforeHost = true,
                        MeetingAuthentication = true,
                        MuteUponEntry = true
                    }
                }, creatorEmail);

            return new ZoomMeeting
            {
                GroupId = timetable.GroupId,
                LessonId = timetable.LessonId,
                ZoomId = createdMeeting.Id,
            };
        }

        public async Task EditTimetableEntryAsync(TimetableEntryDeleteDTO timetable)
        {

        }

        public async Task DeleteTimetableEntryAsync(TimetableEntryDeleteDTO timetable)
        {

        }
    }
}
