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
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;
        private readonly IMapper _mapper;
        private readonly IValidator<Hotel> _validator;

        public HotelController(IHotelService service, IMapper mapper, IValidator<Hotel> validator)
        {
            _service = service;
            _mapper = mapper;
            _validator = validator;
        }

        [Route("Hotels")]
        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var result = await _service.GetHotels();

            return Ok(_mapper.Map<IEnumerable<HotelDTO>>(result));
        }

        [Route("Hotels")]
        [HttpPost]
        public async Task<IActionResult> PostHotel([FromBody] HotelDTO hotelDTO)
        {
            var hotel = _mapper.Map<Hotel>(hotelDTO);

            var validation = _validator.Validate(hotel);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.AddHotel(hotel);

            return Ok();
        }

        [Route("Hotels/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _service.DeleteHotel(id);

            return Ok();
        }

        [Route("Hotels/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var result = await _service.GetHotelById(id);

            return Ok(_mapper.Map<HotelDTO>(result));
        }

        [Route("Hotels/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] HotelDTO hotelDTO)
        {
            hotelDTO.Id = id;

            var hotel = _mapper.Map<Hotel>(hotelDTO);

            var validation = _validator.Validate(hotel);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _service.UpdateHotel(hotel);

            return Ok();
        }

        [Route("Hotels/City/{id}")]
        [HttpGet]
        public IActionResult GetHotelsByCityId(int id)
        {
            var result = _service.GetHotelsByCityId(id);

            return Ok(_mapper.Map<IEnumerable<HotelDTO>>(result));
        }
    }
}
