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
            return await this.lessonRepository.GetByIdAsync(id);
        }

        public Task AddLessonAsync(LessonDTO course)
        {

        }

        public Task<IEnumerable<LessonDTO>> GetLessonsByCourseIdAsync(string name)
        {

        }

        //temporary returning boolean
        public Task<bool> DeleteLessonAsync(int id)
        {

        }
    }
}
