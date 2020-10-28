using AutoMapper;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public class CourseService: ICourseService
    {
        private readonly IRepository<Course> repository;

        private readonly IMapper mapper;

        public CourseService(IRepository<Course> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CourseDTO> GetCourseByIdAsync(int id)
        {
            var course = await this.repository.GetByIdAsync(id);
            return this.mapper.Map<CourseDTO>(course);
        }

        public async Task AddCourseAsync(CourseDTO courseDto)
        {
            var course = this.mapper.Map<Course>(courseDto);
            await this.repository.AddAsync(course);
        }
    }
}
