using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Countries.Handlers
{
    public class GetCountryByIdHandler : IRequestHandler<GetCountryByIdQuery, Country>
    {
        private readonly ICountryService _countryService;

        public GetCountryByIdHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<Country> Handle(GetCountryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _countryService.GetCountryById(request.Id);
        }
    }
}