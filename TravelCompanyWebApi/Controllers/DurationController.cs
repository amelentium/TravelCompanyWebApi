using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    [Authorize]
    public class DurationController : ControllerBase
    {
        private readonly IDurationService _service;
        private readonly IMapper _mapper;

        public DurationController(IDurationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Durations")]
        [HttpGet]
        public async Task<IActionResult> GetAllDurations()
        {
            var result = await _service.GetDurations();

            return Ok(_mapper.Map<IEnumerable<DurationDTO>>(result));
        }

        [Route("Durations")]
        [HttpPost]
        public async Task<IActionResult> PostDuration([FromBody] DurationDTO durationDTO)
        {
            var duration = _mapper.Map<Duration>(durationDTO);

            await _service.AddDuration(duration);

            return Ok();
        }

        [Route("Durations/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDuration(byte id)
        {
            await _service.DeleteDuration(id);

            return Ok();
        }

        [Route("Durations/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDurationById(byte id)
        {
            var result = await _service.GetDurationById(id);

            return Ok(_mapper.Map<DurationDTO>(result));
        }

        [Route("Durations/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDuration(byte id, [FromBody] DurationDTO durationDTO)
        {
            durationDTO.Id = id;

            var duration = _mapper.Map<Duration>(durationDTO);

            await _service.UpdateDuration(duration);

            return Ok();
        }
    }
}
