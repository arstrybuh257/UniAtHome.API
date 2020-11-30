using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Timetable;
using UniAtHome.BLL.Interfaces;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Timetable;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = RoleName.TEACHER)]
    public class TimetableController : ControllerBase
    {
        private readonly ITimetableService timetableService;

        private readonly IMapper mapper;

        public TimetableController(ITimetableService timetableService, IMapper mapper)
        {
            this.timetableService = timetableService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTimetable([FromBody] TimetableCreateRequest request)
        {
            TimetableEntryDTO dto = mapper.Map<TimetableEntryDTO>(request);
            await timetableService.CreateTimetableEntryAsync(dto, User.Identity.Name);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetTimetable(int groupId, int lessonId)
        {
            TimetableDTO timetable = await timetableService.GetTimetableWithZoomLinkAsync(
                groupId,
                lessonId,
                User.Identity.Name);
            // TODO: map
            return new JsonResult(timetable);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTimetable([FromBody] TimetableDeleteRequest request)
        {
            var dto = mapper.Map<TimetableEntryDeleteDTO>(request);
            await timetableService.DeleteTimetableEntryAsync(dto, User.Identity.Name);
            return Ok();
        }


        [HttpPatch]
        public async Task<IActionResult> EditTimetable([FromBody] TimetableEditRequest request)
        {
            TimetableEntryDTO dto = mapper.Map<TimetableEntryDTO>(request);
            await timetableService.EditTimetableEntryAsync(dto, User.Identity.Name);
            return Ok();
        }
    }
}
