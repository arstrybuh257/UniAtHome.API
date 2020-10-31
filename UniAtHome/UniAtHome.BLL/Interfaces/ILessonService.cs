using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;

namespace UniAtHome.BLL.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDTO> GetLessonByIdAsync(int id);

        Task AddLessonAsync(LessonDTO lesson);

        Task<IEnumerable<LessonDTO>> GetLessonsByCourseIdAsync(int id);

        //temporary returning boolean
        Task<bool> DeleteLessonAsync(int id);
    }
}
