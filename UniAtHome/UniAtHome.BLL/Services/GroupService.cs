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

        public GroupService(ICourseRepository courseRepository, IGroupRepository groupRepository)
        {
            this.courseRepository = courseRepository;
            this.groupRepository = groupRepository;
        }

        public async Task<int> AddGroupAsync(CreateGroupDTO dto)
        {
            var existingGroup = groupRepository
                .Find(group => group.Name == dto.Name
                && group.CourseMember.CourseId == dto.CourseId);
            if (existingGroup != null)
            {
                throw new BadRequestException("Group already exists!");
            }

            Group group = new Group
            {
                Name = dto.Name,
                CourseMemberId = await courseRepository.GetCourseMemberIdAsync(dto.CourseId, dto.TeacherId)
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

        public async Task AddStudentToGroupAsync(int groupId, string studentId)
        {
            await groupRepository.AddStudentToGroupAsync(groupId, studentId);
            await groupRepository.SaveChangesAsync();
        }

        public async Task RemoveStudentFromGroup(int groupId, string studentId)
        {
            await groupRepository.RemoveStudentFromGroupAsync(groupId, studentId);
            await groupRepository.SaveChangesAsync();
        }

        public async Task<GroupInfoDTO> GetGroupInfo(int groupId)
        {
            Group group = await groupRepository.GetByIdAsync(groupId);
            if (group == null)
            {
                throw new NotFoundException("Group doesn't exist!");
            }
            var students = groupRepository.GetGroupStudents(groupId)
                .Select(st => new StudentDTO
                {
                    Id = st.UserId,
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
