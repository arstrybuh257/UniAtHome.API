﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UniAtHome.BLL.DTOs.UniversityCreation;
using UniAtHome.BLL.Interfaces;
using UniAtHome.WebAPI.Models.UniversityCreation;

namespace UniAtHome.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityCreateController : ControllerBase
    {
        private readonly IUniversityCreationService universityCreationService;

        private readonly IMapper mapper;

        public UniversityCreateController(IUniversityCreationService universityCreationService, IMapper mapper)
        {
            this.universityCreationService = universityCreationService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> MakeCreationRequestAsync([FromBody] UniversitySubmitRequest request)
        {
            var dto = mapper.Map<UniversityCreateDTO>(request);
            await universityCreationService.AddRequestAsync(dto);
            return Ok();
        }
    }
}