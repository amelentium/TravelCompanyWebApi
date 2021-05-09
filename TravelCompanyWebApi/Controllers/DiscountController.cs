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
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Discounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var result = await _service.GetDiscounts();

            return Ok(_mapper.Map<IEnumerable<DiscountDTO>>(result));
        }

        [Route("Discounts")]
        [HttpPost]
        public async Task<IActionResult> PostDiscount([FromBody] DiscountDTO discountDTO)
        {
            var discount = _mapper.Map<Discount>(discountDTO);

            await _service.AddDiscount(discount);

            return Ok();
        }

        [Route("Discounts/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _service.DeleteDiscount(id);

            return Ok();
        }

        [Route("Discounts/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var result = await _service.GetDiscountById(id);

            return Ok(_mapper.Map<DiscountDTO>(result));
        }

        [Route("Discounts/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] DiscountDTO discountDTO)
        {
            discountDTO.Id = id;

            var discount = _mapper.Map<Discount>(discountDTO);

            await _service.UpdateDiscount(discount);

            return Ok();
        }
    }
}
