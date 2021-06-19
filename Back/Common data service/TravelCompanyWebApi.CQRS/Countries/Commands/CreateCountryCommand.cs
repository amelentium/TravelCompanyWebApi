using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Countries.Commands
{
    public class CreateCountryCommand : IRequest
    {
        public Country Country { get; set; }

        public CreateCountryCommand(Country client)
        {
            Country = client;
        }
    }
}
