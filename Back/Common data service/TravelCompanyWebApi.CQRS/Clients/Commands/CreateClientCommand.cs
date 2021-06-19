using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Clients.Commands
{
    public class CreateClientCommand : IRequest
    {
        public Client Client { get; set; }

        public CreateClientCommand(Client client)
        {
            Client = client;
        }
    }
}
