using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TravelCompanyWebApi.CQRS.Countries.Commands;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.CQRS.Countries.Handlers
{
    public class DeleteCountryHandler : IRequestHandler<DeleteCountryCommand>
    {
        private readonly ICountryService _countryService;

        public DeleteCountryHandler(ICountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            await _countryService.DeleteCountry(request.Id);

            return Unit.Value;
        }
    }
}