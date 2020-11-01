using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs;
using UniAtHome.BLL.DTOs.Lesson;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Models.Requests;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class LessonController : ControllerBase
    {
        private ILessonService lessonService;

        private IMapper mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            this.lessonService = lessonService;
            this.mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLessonById(int id)
        {
            var lesson = await lessonService.GetLessonByIdAsync(id);
            if (lesson != null)
            {
                return Ok(lesson);
            }

            return BadRequest();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateLesson([FromBody] CreateLessonRequest request)
        {
            if (request != null && ModelState.IsValid)
            {
                CreateLessonDTO createLessonDTO = new CreateLessonDTO 
                { 
                    Lesson = mapper.Map<LessonDTO>(request), 
                    TeacherEmail = User.Identity.Name 
                };

                await lessonService.AddLessonAsync(createLessonDTO);
                return Ok();
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            //temporary
            if (await lessonService.DeleteLessonAsync(id))
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
