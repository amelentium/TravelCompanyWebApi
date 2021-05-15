using MediatR;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.CQRS.Climates.Commands
{
    public class UpdateClimateCommand : IRequest
    {
        public Climate Climate { get; set; }

        public UpdateClimateCommand(Climate climate)
        {
            Climate = climate;
        }
    }
}
