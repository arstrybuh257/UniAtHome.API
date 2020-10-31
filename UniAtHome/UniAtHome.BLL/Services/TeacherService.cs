using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Auth;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;
using UniAtHome.DAL.Repositories;

namespace UniAtHome.BLL.Services
{
    public class TeacherService: AuthService
    {
        private readonly IRepository<Teacher> teacherRepository;

        private readonly IRepository<Course> courseRepository;

        private readonly IMapper mapper;

        public TeacherService(
            UserRepository usersRepository,
            IAuthTokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory,
            IRepository<Teacher> teacherRepository,
            IRepository<Course> courseRepository,
            IMapper mapper) : base(usersRepository, tokenGenerator, refreshTokenFactory)
        {
            this.teacherRepository = teacherRepository;
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CourseDTO>> GetTeahersCoursesAsync(string teacherEmail)
        {
            var courses = await courseRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Teacher.User.Email == teacherEmail));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<RegistrationResponse> RegisterTeacherAsync(RegistrationRequest request)
        {
            //KOSTIL`
            var regiserResult = await this.RegisterAsync(request);

            if (!regiserResult.IdentityResult.Succeeded)
            {
                return new RegistrationResponse(regiserResult.IdentityResult.Errors);
            }

            await this.teacherRepository.AddAsync(new Teacher { UserId = regiserResult.UserId });
            await this.teacherRepository.SaveChangesAsync();
            return new RegistrationResponse();
        }
    }
}
