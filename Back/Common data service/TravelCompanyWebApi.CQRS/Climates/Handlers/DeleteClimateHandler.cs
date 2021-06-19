using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Climates.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Climates.Handlers
{
    public class DeleteClimateHandler : IRequestHandler<DeleteClimateCommand>
    {
        private readonly IClimateService _climateService;

        public DeleteClimateHandler(IClimateService climateService)
        {
            _climateService = climateService;
        }

        public async Task<Unit> Handle(DeleteClimateCommand request, CancellationToken cancellationToken)
        {
            await _climateService.DeleteClimate(request.Id);

            return Unit.Value;
        }
    }
}