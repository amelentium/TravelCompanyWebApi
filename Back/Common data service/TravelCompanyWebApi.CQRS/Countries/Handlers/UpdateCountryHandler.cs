using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Countries.Handlers
{
    public class UpdateCountryHandler : IRequestHandler<UpdateCountryCommand>
    {
        private readonly ICountryService _countryService;

        public UpdateCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<Unit> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryService.UpdateCountry(request.Country);

            return Unit.Value;
        }
    }
}