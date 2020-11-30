using AutoMapper;
using System;
using System.Linq;
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
    public class TimetableService : ITimetableService
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
            if (timetableDto.DateTime <= DateTime.UtcNow)
            {
                throw new BadRequestException("Can't create the timetable entry in the past!");
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
                        // TODO: handle somehow editing this parameter when new teacher is added to the course
                        // or the host-creator is removed.
                        // I just can't 
                        // г-(T_T)
                        // \/|   |
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
                StartUrl = createdMeeting.StartUrl,
                JoinUrl = createdMeeting.JoinUrl
            };
        }

        public async Task EditTimetableEntryAsync(TimetableEntryDTO newTimetableDto, string userEmail)
        {
            Timetable timetable = await timetablesRepository.GetSingleOrDefaultAsync(
                    tt => tt.GroupId == newTimetableDto.GroupId && tt.LessonId == newTimetableDto.LessonId);
            if (timetable == null)
            {
                throw new NotFoundException("Timetable entry doesn't exist!");
            }

            CopyTimetablePropertiesValuesFromTo(newTimetableDto, timetable);

            ZoomMeeting zoomMeeting = await zoomMeetingRepository.GetSingleOrDefaultAsync(
                zm => zm.GroupId == timetable.GroupId && zm.LessonId == timetable.LessonId);

            zoomMeeting = await ApplyChangesToZoomMeeting(
                zoomMeeting,
                newTimetableDto,
                timetable,
                userEmail);

            timetablesRepository.Update(timetable);
            await timetablesRepository.SaveChangesAsync();
        }

        private async Task<ZoomMeeting> ApplyChangesToZoomMeeting(
            ZoomMeeting zoomMeeting,
            TimetableEntryDTO newTimetable,
            Timetable oldTimetable,
            string userEmail)
        {
            if (newTimetable.WithZoomMeeting && zoomMeeting != null)
            {
                await EditZoomMeeting(zoomMeeting, oldTimetable, userEmail);
            }
            else if (newTimetable.WithZoomMeeting && zoomMeeting == null)
            {
                zoomMeeting = await CreateZoomMeetingForTimetable(oldTimetable, userEmail);
                await zoomMeetingRepository.AddAsync(zoomMeeting);
            }
            else if (!newTimetable.WithZoomMeeting && zoomMeeting != null)
            {
                await DeleteZoomMeeting(userEmail, zoomMeeting);
            }

            return zoomMeeting;
        }

        private static void CopyTimetablePropertiesValuesFromTo(TimetableEntryDTO from, Timetable to)
        {
            to.Date = from.DateTime;
        }

        private async Task EditZoomMeeting(
            ZoomMeeting zoomMeeting,
            Timetable newTimetable,
            string userEmail)
        {
            await zoomMeetingService.EditMeetingAsync(zoomMeeting.ZoomId, new ZoomMeetingEditDTO
            {
                StartTime = newTimetable.Date
            }, userEmail);
        }

        private async Task DeleteZoomMeeting(string userEmail, ZoomMeeting zoomMeeting)
        {
            await zoomMeetingService.DeleteMeetingAsync(zoomMeeting.ZoomId, userEmail);
            zoomMeetingRepository.Remove(zoomMeeting);
        }

        public async Task DeleteTimetableEntryAsync(TimetableEntryDeleteDTO timetableDto, string userEmail)
        {
            Timetable timetable = await timetablesRepository.GetSingleOrDefaultAsync(
                    tt => tt.GroupId == timetableDto.GroupId && tt.LessonId == timetableDto.LessonId);
            if (timetable == null)
            {
                throw new NotFoundException("Timetable entry doesn't exist!");
            }

            ZoomMeeting zoomMeeting = await zoomMeetingRepository.GetSingleOrDefaultAsync(
                zm => zm.GroupId == timetable.GroupId && zm.LessonId == timetable.LessonId);

            if (zoomMeeting != null)
            {
                await DeleteZoomMeeting(userEmail, zoomMeeting);
            }
            timetablesRepository.Remove(timetable);
            await timetablesRepository.SaveChangesAsync();
        }

        public async Task<TimetableDTO> GetTimetableAsync(int groupId, int lessonId)
        {
            Timetable timetable = await timetablesRepository.GetSingleOrDefaultAsync(
                tt => tt.GroupId == groupId && tt.LessonId == lessonId);
            if (timetable == null)
            {
                throw new NotFoundException("Timetable entry doesn't exist!");
            }
            var dto = new TimetableDTO
            {
                GroupId = groupId,
                LessonId = lessonId,
                DateTime = timetable.Date
            };
            return dto;
        }

        public async Task<TimetableDTO> GetTimetableWithZoomLinkAsync(int groupId, int lessonId, string userEmail)
        {
            TimetableDTO dto = await GetTimetableAsync(groupId, lessonId);

            ZoomMeeting zoomMeeting = await zoomMeetingRepository.GetSingleOrDefaultAsync(
                zm => zm.GroupId == dto.GroupId && zm.LessonId == dto.LessonId);
            if (zoomMeeting != null)
            {
                Lesson lesson = await lessonsRepository.GetByIdAsync(dto.LessonId);
                bool isCourseTeacher = courseService.GetCourseMembers(lesson.CourseId)
                    .Any(t => t.Email == userEmail);

                dto.ZoomUrl = isCourseTeacher ? zoomMeeting.StartUrl : zoomMeeting.JoinUrl;
            }
            return dto;
        }
    }
}
