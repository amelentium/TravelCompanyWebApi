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
    public class PassController : ControllerBase
    {
        private readonly IPassService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<Pass> _validator;

        public PassController(IPassService service, IMapper mapper, IValidator<Pass> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [Route("Passes")]
        [HttpGet]
        public async Task<IActionResult> GetAllPasses()
        {
            var result = await _service.GetPasses();

            return Ok(_mapper.Map<IEnumerable<PassOutputDTO>>(result));
        }

        [Route("Passes")]
        [HttpPost]
        public async Task<IActionResult> PostPass([FromBody] PassInputDTO passDTO)
        {
            var pass = _mapper.Map<Pass>(passDTO);

            var validation = _validator.Validate(pass);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.AddPass(pass);

            return Ok();
        }

        [Route("Passes/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePass(int id)
        {
            await _service.DeletePass(id);

            return Ok();
        }

        [Route("Passes/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPassById(int id)
        {
            var result = await _service.GetPassById(id);

            return Ok(_mapper.Map<PassOutputDTO>(result));
        }

        [Route("Passes/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePass(int id, [FromBody] PassInputDTO passDTO)
        {
            passDTO.Id = id;

            var pass = _mapper.Map<Pass>(passDTO);

            var validation = _validator.Validate(pass);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.UpdatePass(pass);

            return Ok();
        }

        [Route("Passes/Client/{id}")]
        [HttpGet]
        public IActionResult GetPassesByClientId(int id)
        {
            var result = _service.GetPassesByClientId(id);

            return Ok(_mapper.Map<IEnumerable<PassOutputDTO>>(result));
        }

        [Route("Passes/Tour/{id}")]
        [HttpGet]
        public IActionResult GetPassesByTourId(int id)
        {
            var result = _service.GetPassesByTourId(id);

            return Ok(_mapper.Map<IEnumerable<PassOutputDTO>>(result));
        }
    }
}
