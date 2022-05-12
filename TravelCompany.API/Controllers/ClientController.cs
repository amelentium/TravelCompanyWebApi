using Microsoft.AspNetCore.Mvc;
using TravelCompany.Application.Service.Interface;
using TravelCompany.Domain.Entity;

namespace TravelCompany.API.Controllers
{
    [ApiController]
    [Route("Clients")]
    public class ClientController : ControllerBase
    {
        private readonly IGenericService<Client> _service;

        public ClientController(IGenericService<Client> service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client client)
		{
            await _service.AddAsync(client);

            return Ok();
		}

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetById(int id)
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
        public async Task<IActionResult> Update(int id, [FromBody] Client client)
        {
            client.Id = id;

            await _service.UpdateAsync(client);

            return Ok();
        }
    }
}