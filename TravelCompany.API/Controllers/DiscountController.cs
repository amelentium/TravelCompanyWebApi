using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Discounts")]
    public class DiscountController : ControllerBase
    {
        private readonly IGenericService<Discount> _service;

        public DiscountController(IGenericService<Discount> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Discount discount)
		{
            await _service.AddAsync(discount);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<Discount>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetById(int id)
        {
            return await _service.GetByIdAsync(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Discount discount)
        {
            discount.Id = id;

            await _service.UpdateAsync(discount);

            return Ok();
        }
    }
}