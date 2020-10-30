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
    public class StudentsService : AuthService, IStudentsService
    {
        private readonly IRepository<Student> studentRepository;

        private readonly IRepository<Course> coursesRepository;

        private readonly IMapper mapper;

        public StudentsService(
            UsersRepository usersRepository,
            IAuthTokenGenerator tokenGenerator,
            IRefreshTokenFactory refreshTokenFactory,
            IRepository<Student> studentRepository, 
            IRepository<Course> coursesRepository, 
            IMapper mapper): base(usersRepository, tokenGenerator, refreshTokenFactory)
        {
            this.studentRepository = studentRepository;
            this.coursesRepository = coursesRepository;
        }

        public async Task<IEnumerable<CourseDTO>> GetStudentsCoursesAsync(string studentEmail)
        {
            var courses = await coursesRepository.Find(
                course => course.CourseMembers.Any(
                    members => members.Groups.Any(
                        group => group.StudentGroups.Any(
                            studentGroup => studentGroup.Student.User.Email == studentEmail))));

            return this.mapper.Map<IEnumerable<CourseDTO>>(courses);
        }

        public async Task<RegistrationResponse> RegisterStudentAsync(RegistrationRequest request)
        {
            var regiserResult = await this.RegisterAsync(request);

            if (!regiserResult.IdentityResult.Succeeded)
            {
                return new RegistrationResponse(regiserResult.IdentityResult.Errors);
            }

            await this.studentRepository.AddAsync(new Student { UserId = regiserResult.UserId });
            await this.studentRepository.SaveChangesAsync();
            return new RegistrationResponse();
        }
    }
}
