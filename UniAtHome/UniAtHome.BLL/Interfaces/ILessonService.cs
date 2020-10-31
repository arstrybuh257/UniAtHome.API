using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;

namespace UniAtHome.BLL.Interfaces
{
    public interface ILessonService
    {
        Task<LessonDTO> GetLessonByIdAsync(int id);

        Task AddLessonAsync(LessonDTO course);

        Task<IEnumerable<LessonDTO>> GetLessonsByCourseIdAsync(string name);

        //temporary returning boolean
        Task<bool> DeleteLessonAsync(int id);
    }
}
