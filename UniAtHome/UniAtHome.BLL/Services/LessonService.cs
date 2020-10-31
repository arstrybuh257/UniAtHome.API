using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class LessonService: ILessonService
    {
        private readonly IRepository<Lesson> lessonRepository;

        private readonly IMapper mapper;

        public LessonService(IRepository<Lesson> lessonRepository, IMapper mapper)
        {
            this.lessonRepository = lessonRepository;
            this.mapper = mapper;
        }

        public async Task<LessonDTO> GetLessonByIdAsync(int id)
        {
            return mapper.Map<LessonDTO>(await lessonRepository.GetByIdAsync(id));
        }

        public async Task AddLessonAsync(LessonDTO lessonDto)
        {
            //TODO: check if category exists or handle error
            var lesson = mapper.Map<Lesson>(lessonDto);
            await lessonRepository.AddAsync(lesson);
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
