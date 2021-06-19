using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Commands;
using TravelCompanyWebApi.CQRS.Countries.Queries;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    //[Authorize]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<Country> _validator;

        public CountryController(IMediator mediator, IMapper mapper, IValidator<Country> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
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

            var validation = _validator.Validate(country);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

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

            var validation = _validator.Validate(country);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _mediator.Send(new UpdateCountryCommand(country));

            return Ok();
        }
    }
}
