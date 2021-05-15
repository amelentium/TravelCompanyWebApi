using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Countries.Commands
{
    public class UpdateCountryCommand : IRequest
    {
        public Country Country { get; set; }

        public UpdateCountryCommand(Country client)
        {
            Country = client;
        }
    }
}
