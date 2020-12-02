using AutoMapper;
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
    [ApiController, Authorize(Roles = RoleName.STUDENT)]
    public class TestTakeController : Controller
    {
        private readonly ITestTakingService testTakingService;

        private readonly IMapper mapper;

        public TestTakeController(
            ITestTakingService testTakingService,
            IMapper mapper)
        {
            this.testTakingService = testTakingService;
            this.mapper = mapper;
        }

        [HttpPost("start")]
        public async Task<IActionResult> BeginTestAsync([FromBody] TestBeginRequest request)
        {
            var result = await testTakingService.StartTestAsync(request.TestId, User.Identity.Name);
            // TODO: replace with a view model
            return Json(result);
        }

        [HttpPatch("answer")]
        public async Task<IActionResult> AnswerQuestionAsync([FromBody] TestAnswerRequest request)
        {
            var dto = mapper.Map<AnswerSubmitDTO>(request);
            dto.Email = User.Identity.Name;
            await testTakingService.SubmitAnswerAsync(dto);
            return Ok();
        }

        [HttpPost("finish")]
        public async Task<IActionResult> FinishAttemptAsync([FromBody] TestFinishRequest finishRequest)
        {
            var result = await testTakingService
                .FinishAsync(finishRequest.AttemptId, User.Identity.Name);
            // TODO: replace with a view model
            return Json(result);
        }

        [HttpGet("results")]
        public async Task<IActionResult> GetTestResultsAsync(int testId)
        {
            var results = await testTakingService
                .GetAllFinishedAttemptsAsync(testId, User.Identity.Name);
            // TODO: replace with a view model
            return Json(results);
        }
    }
}
