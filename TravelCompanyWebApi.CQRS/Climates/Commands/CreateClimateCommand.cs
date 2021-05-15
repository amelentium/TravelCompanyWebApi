using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Climates.Commands
{
    public class CreateClimateCommand : IRequest
    {
        public Climate Climate { get; set; }

        public CreateClimateCommand(Climate climate)
        {
            Climate = climate;
        }
    }
}
