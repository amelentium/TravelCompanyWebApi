using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Clients.Commands
{
    public class UpdateClientCommand : IRequest
    {
        public Client Client { get; set; }

        public UpdateClientCommand(Client client)
        {
            Client = client;
        }
    }
}
