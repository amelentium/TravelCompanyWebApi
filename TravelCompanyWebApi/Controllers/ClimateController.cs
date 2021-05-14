using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class ClimateController : ControllerBase
    {
        private readonly IClimateService _service;
        private readonly IMapper _mapper;

        public ClimateController(IClimateService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Climates")]
        [HttpGet]
        public async Task<IActionResult> GetAllClimates()
        {
            var result = await _service.GetClimates();

            return Ok(_mapper.Map<IEnumerable<ClimateDTO>>(result));
        }

        [Route("Climates")]
        [HttpPost]
        public async Task<IActionResult> PostClimate([FromBody] ClimateDTO climateDTO)
        {
            var climate = _mapper.Map<Climate>(climateDTO);

            await _service.AddClimate(climate);

            return Ok();
        }

        [Route("Climates/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClimate(byte id)
        {
            await _service.DeleteClimate(id);

            return Ok();
        }

        [Route("Climates/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClimateById(byte id)
        {
            var result = await _service.GetClimateById(id);

            return Ok(_mapper.Map<ClimateDTO>(result));
        }

        [Route("Climates/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateClimate(byte id, [FromBody] ClimateDTO climateDTO)
        {
            climateDTO.Id = id;

            var climate = _mapper.Map<Climate>(climateDTO);

            await _service.UpdateClimate(climate);

            return Ok();
        }
    }
}
