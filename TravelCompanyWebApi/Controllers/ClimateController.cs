using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Climates.Commands;
using TravelCompanyWebApi.CQRS.Climates.Queries;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class ClimateController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<Climate> _validator;

        public ClimateController(IMediator mediator, IMapper mapper, IValidator<Climate> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
        }

        [Route("Climates")]
        [HttpGet]
        public async Task<IActionResult> GetAllClimates()
        {
            var result = await _mediator.Send(new GetAllClimatesQuery());

            return Ok(_mapper.Map<IEnumerable<ClimateDTO>>(result));
        }

        [Route("Climates")]
        [HttpPost]
        public async Task<IActionResult> PostClimate([FromBody] ClimateDTO climateDTO)
        {
            var climate = _mapper.Map<Climate>(climateDTO);

            var validation = _validator.Validate(climate);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _mediator.Send(new CreateClimateCommand(climate));

            return Ok();
        }

        [Route("Climates/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClimate(byte id)
        {
            await _mediator.Send(new DeleteClimateCommand(id));

            return Ok();
        }

        [Route("Climates/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClimateById(byte id)
        {
            var result = await _mediator.Send(new GetClimateByIdQuery(id));

            return Ok(_mapper.Map<ClimateDTO>(result));
        }

        [Route("Climates/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateClimate(byte id, [FromBody] ClimateDTO climateDTO)
        {
            climateDTO.Id = id;

            var climate = _mapper.Map<Climate>(climateDTO);

            var validation = _validator.Validate(climate);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _mediator.Send(new UpdateClimateCommand(climate));

            return Ok();
        }
    }
}
