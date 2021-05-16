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
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;
        private readonly IMapper _mapper;

        public CityController(ICityService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Cities")]
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await _service.GetCities();

            return Ok(_mapper.Map<IEnumerable<CityDTO>>(result));
        }

        [Route("Cities")]
        [HttpPost]
        public async Task<IActionResult> PostCity([FromBody] CityDTO cityDTO)
        {
            var city = _mapper.Map<City>(cityDTO);

            await _service.AddCity(city);

            return Ok();
        }

        [Route("Cities/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int id)
        {
            await _service.DeleteCity(id);

            return Ok();
        }

        [Route("Cities/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCityById(int id)
        {
            var result = await _service.GetCityById(id);

            return Ok(_mapper.Map<CityDTO>(result));
        }

        [Route("Cities/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCity(int id, [FromBody] CityDTO cityDTO)
        {
            cityDTO.Id = id;

            var city = _mapper.Map<City>(cityDTO);

            await _service.UpdateCity(city);

            return Ok();
        }

        [Route("Cities/Climate/{id}")]
        [HttpGet]
        public IActionResult GetCitiesByClimateId(byte id)
        {
            var result = _service.GetCitiesByClimateId(id);

            return Ok(_mapper.Map<IEnumerable<CityDTO>>(result));
        }

        [Route("Cities/Country/{id}")]
        [HttpGet]
        public IActionResult GetCitiesByCountryId(int id)
        {
            var result = _service.GetCitiesByCountryId(id);

            return Ok(_mapper.Map<IEnumerable<CityDTO>>(result));
        }
    }
}
