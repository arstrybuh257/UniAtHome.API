using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.Test;
using UniAtHome.BLL.Interfaces.Test;
using UniAtHome.DAL.Constants;
using UniAtHome.WebAPI.Models.Test;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize(Roles = RoleName.TEACHER)]
    public class TestCreateController : Controller
    {
        private readonly ITestCreationService testCreationService;

        private readonly ITestQuestionCreationService testQuestionCreationService;

        private readonly ITestAnswerCreationService testAnswerCreationService;

        private readonly ITestSchedulingService testSchedulingService;

        private readonly ITestFullInfoService testFullInfoService;

        public TestCreateController(
            ITestCreationService testCreationService,
            ITestQuestionCreationService testQuestionCreationService,
            ITestAnswerCreationService testAnswerCreationService,
            ITestSchedulingService testSchedulingService,
            ITestFullInfoService testFullInfoService)
        {
            this.testCreationService = testCreationService;
            this.testQuestionCreationService = testQuestionCreationService;
            this.testAnswerCreationService = testAnswerCreationService;
            this.testSchedulingService = testSchedulingService;
            this.testFullInfoService = testFullInfoService;
        }

        [HttpGet("full")]
        public async Task<IActionResult> GetTestFullInfo(int id)
        {
            var dto = await testFullInfoService.GetTestFullInfoAsync(id);
            return Json(dto);
        }

        [HttpPost("test")]
        public async Task<IActionResult> CreateTest([FromBody] TestCreateRequest request)
        {
            int id = await testCreationService.CreateTestAsync(request);
            return Json(new { id });
        }

        [HttpPost("question")]
        public async Task<IActionResult> CreateQuestion([FromBody] TestQuestionCreateRequest request)
        {
            int id = await testQuestionCreationService.CreateQuestionAsync(request);
            return Json(new { id });
        }

        [HttpPost("answer")]
        public async Task<IActionResult> CreateAnswer([FromBody] TestAnswerCreateRequest request)
        {
            int id = await testAnswerCreationService.CreateAnswerVariantAsync(request);
            return Json(new { id });
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> CreateSchedule([FromBody] TestScheduleCreateRequest request)
        {
            int id = await testSchedulingService.ScheduleTestAsync(request);
            return Json(new { id });
        }

        [HttpPatch("test")]
        public async Task<IActionResult> EditTest([FromBody] TestEditRequest request)
        {
            await testCreationService.EditTestAsync(request);
            return Ok();
        }

        [HttpPatch("question")]
        public async Task<IActionResult> EditQuestion([FromBody] TestQuestionEditRequest request)
        {
            await testQuestionCreationService.EditQuestionAsync(request);
            return Ok();
        }

        [HttpPatch("answer")]
        public async Task<IActionResult> EditAnswer([FromBody] TestAnswerEditRequest request)
        {
            await testAnswerCreationService.EditAnswerVariantAsync(request);
            return Ok();
        }

        [HttpPatch("schedule")]
        public async Task<IActionResult> EditSchedule([FromBody] TestScheduleEditRequest request)
        {
            await testSchedulingService.EditTestScheduleAsync(request);
            return Ok();
        }

        [HttpDelete("test")]
        public async Task<IActionResult> DeleteTest([FromBody] TestDeleteRequest request)
        {
            await testCreationService.DeleteTestAsync(request.Id);
            return Ok();
        }

        [HttpDelete("question")]
        public async Task<IActionResult> DeleteQuestion([FromBody] TestQuestionDeleteRequest request)
        {
            await testQuestionCreationService.DeleteQuestionAsync(request.Id);
            return Ok();
        }

        [HttpDelete("answer")]
        public async Task<IActionResult> DeleteAnswer([FromBody] TestAnswerDeleteRequest request)
        {
            await testAnswerCreationService.DeleteAnswerVariantAsync(request.Id);
            return Ok();
        }

        [HttpDelete("schedule")]
        public async Task<IActionResult> DeleteSchedule([FromBody] TestScheduleDeleteRequest request)
        {
            await testSchedulingService.RemoveTestFromScheduleAsync(request.Id);
            return Ok();
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetTest(int id)
        {
            TestDTO test = await testCreationService.GetTestAsync(id);
            // TODO: replace with a view model
            return Json(test);
        }

        [HttpGet("question")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            TestQuestionDTO question = await testQuestionCreationService.GetQuestionAsync(id);
            // TODO: replace with a view model
            return Json(question);
        }

        [HttpGet("answer")]
        public async Task<IActionResult> GetAnswer(int id)
        {
            TestAnswerVariantDTO answer = await testAnswerCreationService.GetAnswerVariantAsync(id);
            // TODO: replace with a view model
            return Json(answer);
        }

        [HttpGet("schedule")]
        public async Task<IActionResult> GetSchedule(int id)
        {
            TestScheduleDTO schedule = await testSchedulingService.GetTestScheduleAsync(id);
            // TODO: replace with a view model
            return Json(schedule);
        }
    }
}
