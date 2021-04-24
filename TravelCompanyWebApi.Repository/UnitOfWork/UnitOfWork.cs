using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;

namespace TravelCompanyWebApi.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClimateRepository _climateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly TravelCompanyDBContext _context;

        public UnitOfWork(IClientRepository clientRepository, IClimateRepository climateRepository, ICountryRepository countryRepository, IDiscountRepository discountRepository, TravelCompanyDBContext context)
        {
            _clientRepository = clientRepository;
            _climateRepository = climateRepository;
            _countryRepository = countryRepository;
            _discountRepository = discountRepository;
            _context = context;
        }

        public IClientRepository ClientRepository => _clientRepository;

        public IClimateRepository ClimateRepository => _climateRepository;

        public ICountryRepository CountryRepository => _countryRepository;

        public IDiscountRepository DiscountRepository => _discountRepository;

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
