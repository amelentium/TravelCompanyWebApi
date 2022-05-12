using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Tours")]
    public class TourController : ControllerBase
    {
        private readonly IGenericService<Tour> _service;

        public TourController(IGenericService<Tour> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tour tour)
		{
            await _service.AddAsync(tour);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<Tour>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tour>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] Tour tour)
        {
            tour.Id = id;

            await _service.UpdateAsync(tour);

            return Ok();
        }
    }
}