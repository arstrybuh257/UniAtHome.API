using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Group;
using UniAtHome.BLL.Exceptions;
using UniAtHome.BLL.Interfaces;
using UniAtHome.BLL.Services;
using UniAtHome.WebAPI.Models.Group;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class GroupController : ControllerBase
    {
        private readonly GroupService groupService;

        private readonly IUniversityService universityService;

        private readonly ICourseService courseService;

        public GroupController(
            GroupService groupService,
            IUniversityService universityService,
            ICourseService courseService)
        {
            this.groupService = groupService;
            this.universityService = universityService;
            this.courseService = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] GroupCreateRequest request)
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
                TeacherId = request.TeacherId,
                Name = request.GroupName
            };
            await groupService.AddGroupAsync(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            // TODO: Add access validation
            await groupService.DeleteGroupAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfo(int id)
        {
            GroupInfoDTO group = await groupService.GetGroupInfo(id);

            return Ok(new
            {
                group.Id,
                group.Name,
                Students = group.Students
                    .Select(s => new
                    {
                        s.Id,
                        s.FirstName,
                        s.LastName
                    })
            });
        }

        [HttpPost("addStudent")]
        public async Task<IActionResult> AddStudentToGroup([FromBody] AddStudentToGroupRequest request)
        {
            // TODO: Add access validation, again
            await groupService.AddStudentToGroupAsync(request.GroupId, request.StudentId);
            return Ok();
        }

        [HttpPost("removeStudent")]
        public async Task<IActionResult> RemoveStudentFromGroup([FromBody] RemoveStudentFromGroupRequest request)
        {
            // TODO: Add access validation, and again
            await groupService.RemoveStudentFromGroup(request.GroupId, request.StudentId);
            return Ok();
        }
    }
}