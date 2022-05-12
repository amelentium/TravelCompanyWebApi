using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Countries")]
    public class CountryController : ControllerBase
    {
        private readonly IGenericService<Country> _service;

        public CountryController(IGenericService<Country> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Country country)
		{
            await _service.AddAsync(country);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] Country country)
        {
            country.Id = id;

            await _service.UpdateAsync(country);

            return Ok();
        }
    }
}