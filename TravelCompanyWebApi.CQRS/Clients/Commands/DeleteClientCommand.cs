using MediatR;

namespace TravelCompanyWebApi.CQRS.Clients.Commands
{
    public class DeleteClientCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteClientCommand(int id)
        {
            Id = id;
        }
    }
}
