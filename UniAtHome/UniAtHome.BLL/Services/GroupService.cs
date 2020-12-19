using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Group;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Entities;
using UniAtHome.DAL.Interfaces;

namespace UniAtHome.BLL.Services
{
    public sealed class GroupService : IGroupService
    {
        private readonly ICourseRepository courseRepository;

        private readonly IGroupRepository groupRepository;

        private readonly IRepository<Student> studentsRepository;

        private readonly ITeacherRepository teacherRepository;

        public GroupService(
            ICourseRepository courseRepository,
            IGroupRepository groupRepository,
            IRepository<Student> studentsRepository,
            ITeacherRepository teacherRepository)
        {
            this.courseRepository = courseRepository;
            this.groupRepository = groupRepository;
            this.studentsRepository = studentsRepository;
            this.teacherRepository = teacherRepository;
        }

        public async Task<int> AddGroupAsync(CreateGroupDTO dto)
        {
            Group existingGroup = (await groupRepository
                .Find(group => group.Name == dto.Name
                && group.CourseMember.CourseId == dto.CourseId))
                .FirstOrDefault();
            if (existingGroup != null)
            {
                throw new BadRequestException("Group already exists.");
            }

            var teacher = await teacherRepository.GetByEmailAsync(dto.TeacherEmail);
            int? courseMemberId = await courseRepository.GetCourseMemberIdAsync(
                dto.CourseId, teacher.UserId);
            if (courseMemberId == null)
            {
                throw new BadRequestException("The teacher doesn't belong to the course.");
            }

            Group group = new Group
            {
                Name = dto.Name,
                CourseMemberId = courseMemberId.Value
            };
            await groupRepository.AddAsync(group);
            await groupRepository.SaveChangesAsync();
            return group.Id;
        }

        public async Task DeleteGroupAsync(int groupId)
        {
            Group group = await groupRepository.GetByIdAsync(groupId);
            if (group == null)
            {
                throw new BadRequestException("Group doesn't exist!");
            }
            groupRepository.Remove(group);
            await groupRepository.SaveChangesAsync();
        }

        public async Task AddStudentToGroupAsync(int groupId, string studentEmail)
        {
            Student student = (await studentsRepository.Find(s => s.User.Email == studentEmail)).FirstOrDefault();
            if (student == null)
            {
                throw new BadRequestException("Student doesn't exist");
            }
            await groupRepository.AddStudentToGroupAsync(groupId, student.UserId);
            await groupRepository.SaveChangesAsync();
        }

        public async Task RemoveStudentFromGroupAsync(int groupId, string studentEmail)
        {
            Student student = (await studentsRepository.Find(s => s.User.Email == studentEmail)).FirstOrDefault();
            if (student == null)
            {
                throw new BadRequestException("Student doesn't exist");
            }
            if (!await groupRepository.IsStudentInGroupAsync(groupId, student.UserId))
            {
                throw new BadRequestException("The student isn't in the group!");
            }
            await groupRepository.RemoveStudentFromGroupAsync(groupId, student.UserId);
            await groupRepository.SaveChangesAsync();
        }

        public async Task<GroupInfoDTO> GetGroupInfoAsync(int groupId)
        {
            Group group = await groupRepository.GetByIdAsync(groupId);
            if (group == null)
            {
                throw new NotFoundException("Group doesn't exist!");
            }
            var students = groupRepository.GetGroupStudents(groupId)
                .Select(st => new StudentDTO
                {
                    Email = st.User.Email,
                    FirstName = st.User.FirstName,
                    LastName = st.User.LastName
                });

            return new GroupInfoDTO
            {
                Id = groupId,
                Name = group.Name,
                Students = students
            };
        }
    }
}
