using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IValidator<Discount> _validator;

        public DiscountController(IMediator mediator, IMapper mapper, IValidator<Discount> validator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _validator = validator;
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

            var validation = _validator.Validate(discount);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

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

            var validation = _validator.Validate(discount);
            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors.Select(x => x.ErrorMessage).ToList());
            }

            await _mediator.Send(new UpdateDiscountCommand(discount));

            return Ok();
        }
    }
}
