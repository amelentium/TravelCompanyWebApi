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
    public class PassDiscountController : ControllerBase
    {
        private readonly IPassDiscountService _service;
        private readonly IMapper _mapper;

        public PassDiscountController(IPassDiscountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("PassDiscounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllPassDiscounts()
        {
            var result = await _service.GetPassDiscounts();

            return Ok(_mapper.Map<IEnumerable<PassDiscountDTO>>(result));
        }

        [Route("PassDiscounts")]
        [HttpPost]
        public async Task<IActionResult> PostPassDiscount([FromBody] PassDiscountDTO passDiscountDTO)
        {
            var passDiscount = _mapper.Map<PassDiscount>(passDiscountDTO);

            await _service.AddPassDiscount(passDiscount);

            return Ok();
        }

        [Route("PassDiscounts/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeletePassDiscount(int id)
        {
            await _service.DeletePassDiscount(id);

            return Ok();
        }

        [Route("PassDiscounts/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPassDiscountById(int id)
        {
            var result = await _service.GetPassDiscountById(id);

            return Ok(_mapper.Map<PassDiscountDTO>(result));
        }

        [Route("PassDiscounts/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdatePassDiscount(int id, [FromBody] PassDiscountDTO passDiscountDTO)
        {
            passDiscountDTO.Id = id;

            var passDiscount = _mapper.Map<PassDiscount>(passDiscountDTO);

            await _service.UpdatePassDiscount(passDiscount);

            return Ok();
        }

        [Route("PassDiscounts/Discount/{id}")]
        [HttpGet]
        public IActionResult GetPassDiscountsByDiscountId(int id)
        {
            var result = _service.GetPassDiscountsByDiscountId(id);

            return Ok(_mapper.Map<IEnumerable<PassDiscountDTO>>(result));
        }

        [Route("PassDiscounts/Pass/{id}")]
        [HttpGet]
        public IActionResult GetPassDiscountsByPassId(int id)
        {
            var result = _service.GetPassDiscountsByPassId(id);

            return Ok(_mapper.Map<IEnumerable<PassDiscountDTO>>(result));
        }
    }
}
