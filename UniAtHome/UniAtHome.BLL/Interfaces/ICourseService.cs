﻿using System.Collections.Generic;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Course;

namespace UniAtHome.BLL.Interfaces
{
    public interface ICourseService
    {
        Task<CourseDTO> GetCourseByIdAsync(int id);

        Task<CourseDTO> GetCourseWithLessonsByIdAsync(int id);

        Task AddCourseAsync(CourseDTO course);

        Task<IEnumerable<CourseDTO>> GetCoursesByNameAsync(string name);

        //temporary returning boolean
        Task<bool> DeleteCourseAsync(int id);
    }
}
