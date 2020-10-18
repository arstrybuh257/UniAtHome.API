using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get() => Ok("OK");
    }

    // TODO: delete it after db is configured
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private IConfiguration configuration;

        public DbTestController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Connection string is: " + configuration.GetConnectionString("DefaultConnection");
        }
    }


}
