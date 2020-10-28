using AutoMapper;
using UniAtHome.BLL.DTOs;
using UniAtHome.DAL.Entities;

namespace UniAtHome.BLL.Util
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseDTO>().ReverseMap();
        }
    }
}
