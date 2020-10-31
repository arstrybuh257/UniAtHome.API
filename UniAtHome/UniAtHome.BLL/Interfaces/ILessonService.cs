using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Lesson;

namespace UniAtHome.BLL.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDTO> GetLessonByIdAsync(int id);

        Task<IEnumerable<LessonDTO>> GetLessonsByCourseIdAsync(int id);

        //temporary returning boolean
        Task<bool> DeleteLessonAsync(int id);

        //temporary returning boolean
        Task<bool> AddLessonAsync(CreateLessonDTO createLessonDTO);
    }
}
