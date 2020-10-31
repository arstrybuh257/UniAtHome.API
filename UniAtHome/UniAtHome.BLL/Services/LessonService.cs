using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Lesson;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using System.Linq;

namespace UniAtHome.BLL.Services
{
    public class LessonService: ILessonService
    {
        private readonly IRepository<Lesson> lessonRepository;

        private readonly  IRepository<Course> courseRepository;

        private readonly IMapper mapper;

        public LessonService(IRepository<Lesson> lessonRepository, IRepository<Course> courseRepository, IMapper mapper)
        {
            this.lessonRepository = lessonRepository;
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<LessonDTO> GetLessonByIdAsync(int id)
        {
            return mapper.Map<LessonDTO>(await lessonRepository.GetByIdAsync(id));
        }

        //temporary returning boolean
        public async Task<bool> AddLessonAsync(CreateLessonDTO createLessonDTO)
        {
            //TODO: should return erros if category doesn't exist and/or 
            //if the teacher who sent this request can't add lesson to the course they doesn`t belong to
            var course = await courseRepository.GetByIdAsync(createLessonDTO.Lesson.CourseId);
            if (course != null && course.CourseMembers.Where(
                m => m.Teacher.User.Email == createLessonDTO.TeacherEmail).First() != null)
            {
                var lesson = mapper.Map<Lesson>(createLessonDTO.Lesson);
                await lessonRepository.AddAsync(lesson);
                return true;

            }

            return false;
        }

        public async Task<IEnumerable<LessonDTO>> GetLessonsByCourseIdAsync(int id)
        {
            var lessons = await lessonRepository.Find(l => l.CourseId == id);
            return mapper.Map<IEnumerable<LessonDTO>>(lessons);
        }

        //temporary returning boolean
        public async Task<bool> DeleteLessonAsync(int id)
        {
            var lesson = await lessonRepository.GetByIdAsync(id);
            if (lesson != null)
            {
                lessonRepository.Remove(lesson);
                await lessonRepository.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
