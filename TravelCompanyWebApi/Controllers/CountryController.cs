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
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;
        private readonly IMapper _mapper;

        public CountryController(ICountryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Countries")]
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _service.GetCountries();

            return Ok(_mapper.Map<IEnumerable<CountryDTO>>(result));
        }

        [Route("Countries")]
        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);

            await _service.AddCountry(country);

            return Ok();
        }

        [Route("Countries/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _service.DeleteCountry(id);

            return Ok();
        }

        [Route("Countries/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var result = await _service.GetCountryById(id);

            return Ok(_mapper.Map<CountryDTO>(result));
        }

        [Route("Countries/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryDTO countryDTO)
        {
            countryDTO.Id = id;

            var country = _mapper.Map<Country>(countryDTO);

            await _service.UpdateCountry(country);

            return Ok();
        }
    }
}
