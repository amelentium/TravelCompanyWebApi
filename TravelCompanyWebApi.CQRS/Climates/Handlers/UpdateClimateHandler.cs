using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Climates.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Climates.Handlers
{
    public class UpdateClimateHandler : IRequestHandler<UpdateClimateCommand>
    {
        private readonly IClimateService _climateService;

        public UpdateClimateHandler(IClimateService climateService)
        {
            _climateService = climateService;
        }

        public async Task<Unit> Handle(UpdateClimateCommand request, CancellationToken cancellationToken)
        {
            await _climateService.UpdateClimate(request.Climate);

            return Unit.Value;
        }
    }
}