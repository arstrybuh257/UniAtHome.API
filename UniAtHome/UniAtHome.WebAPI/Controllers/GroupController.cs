using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Group;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Models.Group;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        private readonly IUniversityService universityService;

        private readonly ICourseService courseService;

        public GroupController(
            IGroupService groupService,
            IUniversityService universityService,
            ICourseService courseService)
        {
            this.groupService = groupService;
            this.universityService = universityService;
            this.courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupAsync([FromBody] GroupCreateRequest request)
        {
            var course = await courseService.GetCourseByIdAsync(request.CourseId);
            if (course == null)
            {
                throw new BadRequestException("Course doesn't exist");
            }
            if (!await User.IsUniversityTeacherOrHigherAsync(course.UniversityId, universityService))
            {
                throw new ForbiddenException("Don't have rights to create a group for this course!");
            }

            var dto = new CreateGroupDTO
            {
                CourseId = request.CourseId,
                TeacherEmail = request.TeacherEmail,
                Name = request.GroupName
            };
            int id = await groupService.AddGroupAsync(dto);
            return Ok(new
            {
                id
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupAsync(int id)
        {
            // TODO: Add access validation
            await groupService.DeleteGroupAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfoAsync(int id)
        {
            GroupInfoDTO group = await groupService.GetGroupInfoAsync(id);

            return Ok(new
            {
                group.Id,
                group.Name,
                Students = group.Students
                    .Select(s => new
                    {
                        s.Email,
                        s.FirstName,
                        s.LastName
                    })
            });
        }

        [HttpPost("addStudent")]
        public async Task<IActionResult> AddStudentToGroupAsync([FromBody] AddStudentToGroupRequest request)
        {
            // TODO: Add access validation, again
            await groupService.AddStudentToGroupAsync(request.GroupId, request.StudentEmail);
            return Ok();
        }

        [HttpPost("removeStudent")]
        public async Task<IActionResult> RemoveStudentFromGroupAsync([FromBody] RemoveStudentFromGroupRequest request)
        {
            // TODO: Add access validation, and again
            await groupService.RemoveStudentFromGroupAsync(request.GroupId, request.StudentEmail);
            return Ok();
        }
    }
}