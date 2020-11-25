﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniAtHome.BLL.Interfaces.Zoom;
using UniAtHome.WebAPI.Models.Zoom;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class ZoomController : ControllerBase
    {
        private readonly IZoomAuthService zoomAuthService;

        public ZoomController(IZoomAuthService zoomAuthService)
        {
            this.zoomAuthService = zoomAuthService;
        }

        [HttpPost("authorized")]
        public async Task<IActionResult> OnAuthorized([FromBody] ZoomAuthorizedRequest request)
        {
            await zoomAuthService.AuthorizeAsync(User.Identity.Name, request.Code);
            return Ok();
        }
    }
}
