using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UniAtHome.BLL.DTOs.University;
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
        public async Task<ActionResult<IEnumerable<UniversityDTO>>> GetAll()
        {
            return Ok(await universityService.GetUniversities());
        }

    }
}
