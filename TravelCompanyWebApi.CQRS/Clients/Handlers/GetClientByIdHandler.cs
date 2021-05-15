using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Clients.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Clients.Handlers
{
    public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Client>
    {
        private readonly IClientService _clientService;

        public GetClientByIdHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetClientById(request.Id);
        }
    }
}