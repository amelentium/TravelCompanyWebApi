using MediatR;
using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Climates.Queries
{
    public class GetAllClimatesQuery : IRequest<IEnumerable<Climate>>
    {

    }
}