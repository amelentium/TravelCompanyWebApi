using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Climates.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Climates.Handlers
{
    public class GetClimateByIdHandler : IRequestHandler<GetClimateByIdQuery, Climate>
    {
        private readonly IClimateService _climateService;

        public GetClimateByIdHandler(IClimateService climateService)
        {
            _climateService = climateService;
        }

        public async Task<Climate> Handle(GetClimateByIdQuery request, CancellationToken cancellationToken)
        {
            return await _climateService.GetClimateById(request.Id);
        }
    }
}