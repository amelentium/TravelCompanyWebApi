using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Discounts.Commands;
using TravelCompanyWebApi.CQRS.Discounts.Queries;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    [Authorize]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DiscountController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("Discounts")]
        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts()
        {
            var result = await _mediator.Send(new GetAllDiscountsQuery());

            return Ok(_mapper.Map<IEnumerable<DiscountDTO>>(result));
        }

        [Route("Discounts")]
        [HttpPost]
        public async Task<IActionResult> PostDiscount([FromBody] DiscountDTO discountDTO)
        {
            var discount = _mapper.Map<Discount>(discountDTO);

            await _mediator.Send(new CreateDiscountCommand(discount));

            return Ok();
        }

        [Route("Discounts/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            await _mediator.Send(new DeleteDiscountCommand(id));

            return Ok();
        }

        [Route("Discounts/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetDiscountById(int id)
        {
            var result = await _mediator.Send(new GetDiscountByIdQuery(id));

            return Ok(_mapper.Map<DiscountDTO>(result));
        }

        [Route("Discounts/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateDiscount(int id, [FromBody] DiscountDTO discountDTO)
        {
            discountDTO.Id = id;

            var discount = _mapper.Map<Discount>(discountDTO);

            await _mediator.Send(new UpdateDiscountCommand(discount));

            return Ok();
        }
    }
}
