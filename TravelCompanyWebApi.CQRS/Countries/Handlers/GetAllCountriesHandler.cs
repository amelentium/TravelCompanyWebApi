using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Queries;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Countries.Handlers
{
    public class GetAllCountryHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<Country>>
    {
        private readonly ICountryService _countryService;

        public GetAllCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IEnumerable<Country>> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            return await _countryService.GetCountries();
        }
    }
}