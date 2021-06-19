using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Climates.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Climates.Handlers
{
    public class CreateClimateHandler : IRequestHandler<CreateClimateCommand>
    {
        private readonly IClimateService _climateService;

        public CreateClimateHandler(IClimateService climateService)
        {
            _climateService = climateService;
        }

        public async Task<Unit> Handle(CreateClimateCommand request, CancellationToken cancellationToken)
        {
            await _climateService.AddClimate(request.Climate);

            return Unit.Value;
        }
    }
}