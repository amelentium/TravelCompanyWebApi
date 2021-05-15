using MediatR;
using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Countries.Queries
{
    public class GetAllCountriesQuery : IRequest<IEnumerable<Country>>
    {

    }
}