using MediatR;
using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Clients.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<Client>>
    {

    }
}