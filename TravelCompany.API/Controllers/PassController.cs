using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Passes")]
    public class PassController : ControllerBase
    {
        private readonly IGenericService<Pass> _service;

        public PassController(IGenericService<Pass> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pass pass)
		{
            await _service.AddAsync(pass);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<Pass>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pass>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] Pass pass)
        {
            pass.Id = id;

            await _service.UpdateAsync(pass);

            return Ok();
        }
    }
}