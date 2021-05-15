using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Clients.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Clients.Handlers
{
    public class DeleteClientHandler : IRequestHandler<DeleteClientCommand>
    {
        private readonly IClientService _clientService;

        public DeleteClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            await _clientService.DeleteClient(request.Id);

            return Unit.Value;
        }
    }
}