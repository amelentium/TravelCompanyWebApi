using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        public ClientController(IClientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [Route("Clients")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _service.GetClients();

            return Ok(_mapper.Map<IEnumerable<ClientDTO>>(result));
        }

        [Route("Clients")]
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);

            await _service.AddClient(client);

            return Ok();
        }

        [Route("Clients/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _service.DeleteClient(id);

            return Ok();
        }

        [Route("Clients/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClientById(int id)
        {
            var result = await _service.GetClientById(id);

            return Ok(_mapper.Map<ClientDTO>(result));
        }

        [Route("Clients/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientDTO clientDTO)
        {
            clientDTO.Id = id;

            var client = _mapper.Map<Client>(clientDTO);

            await _service.UpdateClient(client);

            return Ok();
        }
    }
}
