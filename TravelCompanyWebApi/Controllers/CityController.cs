using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IValidator<City> _validator;

        public CityController(ICityService service, IMapper mapper, IValidator<City> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
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

            var validation = _validator.Validate(city);
            if(!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

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

            var validation = _validator.Validate(city);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

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
