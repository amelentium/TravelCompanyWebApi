using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Hotels")]
    public class HotelController : ControllerBase
    {
        private readonly IGenericService<Hotel> _service;

        public HotelController(IGenericService<Hotel> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Hotel hotel)
		{
            await _service.AddAsync(hotel);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] Hotel hotel)
        {
            hotel.Id = id;

            await _service.UpdateAsync(hotel);

            return Ok();
        }
    }
}