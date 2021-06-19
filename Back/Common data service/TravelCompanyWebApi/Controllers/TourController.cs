using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    //[Authorize]
    public class TourController : ControllerBase
    {
        private readonly ITourService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<Tour> _validator;

        public TourController(ITourService service, IMapper mapper, IValidator<Tour> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [Route("Tours")]
        [HttpGet]
        public async Task<IActionResult> GetAllTours()
        {
            var result = await _service.GetTours();

            return Ok(_mapper.Map<IEnumerable<TourDTO>>(result));
        }

        [Route("Tours")]
        [HttpPost]
        public async Task<IActionResult> PostTour([FromBody] TourDTO tourDTO)
        {
            var tour = _mapper.Map<Tour>(tourDTO);

            var validation = _validator.Validate(tour);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.AddTour(tour);

            return Ok();
        }

        [Route("Tours/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTour(int id)
        {
            await _service.DeleteTour(id);

            return Ok();
        }

        [Route("Tours/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTourById(int id)
        {
            var result = await _service.GetTourById(id);

            return Ok(_mapper.Map<TourDTO>(result));
        }

        [Route("Tours/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateTour(int id, [FromBody] TourDTO tourDTO)
        {
            tourDTO.Id = id;

            var tour = _mapper.Map<Tour>(tourDTO);

            var validation = _validator.Validate(tour);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.UpdateTour(tour);

            return Ok();
        }

        [Route("Tours/Climate/{climateName}")]
        [HttpGet]
        public IActionResult GetToursByClimateName(string climateName)
        {
            try
            {
                var result = _service.GetToursByClimateName(climateName);

                return Ok(_mapper.Map<IEnumerable<TourDTO>>(result));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [Route("Tours/Duration/{id}")]
        [HttpGet]
        public IActionResult GetToursByDurationId(byte id)
        {
            var result = _service.GetToursByDurationId(id);

            return Ok(_mapper.Map<IEnumerable<TourDTO>>(result));
        }

        [Route("Tours/Hotel/{id}")]
        [HttpGet]
        public IActionResult GetToursByHotelId(int id)
        {
            var result = _service.GetToursByHotelId(id);

            return Ok(_mapper.Map<IEnumerable<TourDTO>>(result));
        }
    }
}
