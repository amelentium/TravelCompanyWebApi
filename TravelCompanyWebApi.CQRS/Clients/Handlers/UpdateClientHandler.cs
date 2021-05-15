using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Clients.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Clients.Handlers
{
    public class UpdateClientHandler : IRequestHandler<UpdateClientCommand>
    {
        private readonly IClientService _clientService;

        public UpdateClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            await _clientService.UpdateClient(request.Client);

            return Unit.Value;
        }
    }
}