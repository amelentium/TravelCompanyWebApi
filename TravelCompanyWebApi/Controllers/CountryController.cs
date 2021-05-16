using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Commands;
using TravelCompanyWebApi.CQRS.Countries.Queries;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CountryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("Countries")]
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            var result = await _mediator.Send(new GetAllCountriesQuery());

            return Ok(_mapper.Map<IEnumerable<CountryDTO>>(result));
        }

        [Route("Countries")]
        [HttpPost]
        public async Task<IActionResult> PostCountry([FromBody] CountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);

            await _mediator.Send(new CreateCountryCommand(country));

            return Ok();
        }

        [Route("Countries/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            await _mediator.Send(new DeleteCountryCommand(id));

            return Ok();
        }

        [Route("Countries/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetCountryById(int id)
        {
            var result = await _mediator.Send(new GetCountryByIdQuery(id));

            return Ok(_mapper.Map<CountryDTO>(result));
        }

        [Route("Countries/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] CountryDTO countryDTO)
        {
            countryDTO.Id = id;

            var country = _mapper.Map<Country>(countryDTO);

            await _mediator.Send(new UpdateCountryCommand(country));

            return Ok();
        }
    }
}
