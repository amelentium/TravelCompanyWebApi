using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Clients.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int Id { get; set; }

        public GetClientByIdQuery(int id)
        {
            Id = id;
        }
    }
}