﻿using BaristaCoffee.API.Repositories.RezervationRepository;
using BaristaCoffee.Dto.RezervationDtos;
using Microsoft.AspNetCore.Mvc;

namespace BaristaCoffee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervationController : ControllerBase
    {
        private readonly IRezervationRepository _rezervationRepository;

        public RezervationController(IRezervationRepository rezervationRepository)
        {
            _rezervationRepository = rezervationRepository;
        }

        [HttpGet("GetAllRezervation")]
        public async Task<IActionResult> GetAllRezervationAsync()
        {
            var result = await _rezervationRepository.GetAllRezervationAsync();
            return Ok(result);
        }

        [HttpGet("GetRezervationById/{id}")]
        public async Task<IActionResult> GetRezervationByIdAsync(int id)
        {
            var result = await _rezervationRepository.GetRezervationByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("CreateRezervation")]
        public async Task<IActionResult> CreateRezervationAsync(CreateRezervationDto createRezervationDto)
        {
            await _rezervationRepository.CreateRezervationAsync(createRezervationDto);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("UpdateRezervation")]
        public async Task<IActionResult> UpdateRezervationAsync(UpdateRezervationDto updateRezervationDto)
        {
            await _rezervationRepository.UpdateRezervationAsync(updateRezervationDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("DeleteRezervation/{id}")]
        public async Task<IActionResult> DeleteRezervationAsync(int id)
        {
            await _rezervationRepository.DeleteRezervationAsync(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
