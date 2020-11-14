using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.Interfaces;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private IUniversityService universityService;

        public UniversityController(IUniversityService universityService)
        {
            this.universityService = universityService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await universityService.GetUniversities());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await universityService.DeleteUniversityAsync(id);
            if (!res)
            {
                return NotFound("This university is not exist.");
            }
            return Ok();
        }
    }
}
