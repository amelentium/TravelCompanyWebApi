using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Clients.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Clients.Handlers
{
    public class GetAllClientHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<Client>>
    {
        private readonly IClientService _clientService;

        public GetAllClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetClients();
        }
    }
}