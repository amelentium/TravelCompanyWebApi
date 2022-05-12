using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("PassDiscounts")]
    public class PassDiscountController : ControllerBase
    {
        private readonly IGenericService<PassDiscount> _service;

        public PassDiscountController(IGenericService<PassDiscount> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PassDiscount passDiscount)
		{
            await _service.AddAsync(passDiscount);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<PassDiscount>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PassDiscount>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] PassDiscount passDiscount)
        {
            passDiscount.Id = id;

            await _service.UpdateAsync(passDiscount);

            return Ok();
        }
    }
}