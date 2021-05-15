using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Countries.Handlers
{
    public class CreateCountryHandler : IRequestHandler<CreateCountryCommand>
    {
        private readonly ICountryService _countryService;

        public CreateCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<Unit> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryService.AddCountry(request.Country);

            return Unit.Value;
        }
    }
}