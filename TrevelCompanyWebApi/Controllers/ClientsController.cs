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
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly IMapper _mapper;

        public ClientsController(IClientService service, IMapper mapper)
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
        public async Task<IActionResult> PostClients([FromBody] ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);

            await _service.AddClient(client);

            return Ok();
        }
    }
}
