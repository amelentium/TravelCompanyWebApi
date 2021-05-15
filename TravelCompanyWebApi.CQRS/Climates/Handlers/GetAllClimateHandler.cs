using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Climates.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Climates.Handlers
{
    public class GetAllClimateHandler : IRequestHandler<GetAllClimatesQuery, IEnumerable<Climate>>
    {
        private readonly IClimateService _climateService;

        public GetAllClimateHandler(IClimateService climateService)
        {
            _climateService = climateService;
        }

        public async Task<IEnumerable<Climate>> Handle(GetAllClimatesQuery request, CancellationToken cancellationToken)
        {
            return await _climateService.GetClimates();
        }
    }
}