using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Cities")]
    public class CityController : ControllerBase
    {
        private readonly IGenericService<City> _service;

        public CityController(IGenericService<City> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City city)
		{
            await _service.AddAsync(city);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<City>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] City city)
        {
            city.Id = id;

            await _service.UpdateAsync(city);

            return Ok();
        }
    }
}