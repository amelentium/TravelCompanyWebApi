using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Countries.Queries
{
    public class GetCountryByIdQuery : IRequest<Country>
    {
        public int Id { get; set; }

        public GetCountryByIdQuery(int id)
        {
            Id = id;
        }
    }
}