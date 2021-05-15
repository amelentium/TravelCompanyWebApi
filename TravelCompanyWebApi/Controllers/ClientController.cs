﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Clients.Commands;
using TravelCompanyWebApi.CQRS.Clients.Queries;
using TravelCompanyWebApi.Infrastructure.DTO;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TrevelCompanyWebApi.Controllers
{
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ClientController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Route("Clients")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _mediator.Send(new GetAllClientsQuery());

            return Ok(_mapper.Map<IEnumerable<ClientDTO>>(result));
        }

        [Route("Clients")]
        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] ClientDTO clientDTO)
        {
            var client = _mapper.Map<Client>(clientDTO);

            await _mediator.Send(new CreateClientCommand(client));

            return Ok();
        }

        [Route("Clients/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteClient(int id)
        {
            await _mediator.Send(new DeleteClientCommand(id));

            return Ok();
        }

        [Route("Clients/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetClientById(int id)
        {
            var result = await _mediator.Send(new GetClientByIdQuery(id));

            return Ok(_mapper.Map<ClientDTO>(result));
        }

        [Route("Clients/{id}")]
        [HttpPut]
        public async Task<IActionResult> UpdateClient(int id, [FromBody] ClientDTO clientDTO)
        {
            clientDTO.Id = id;

            var client = _mapper.Map<Client>(clientDTO);

            await _mediator.Send(new UpdateClientCommand(client));

            return Ok();
        }
    }
}
