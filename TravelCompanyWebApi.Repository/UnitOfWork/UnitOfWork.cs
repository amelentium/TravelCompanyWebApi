using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;

namespace TravelCompanyWebApi.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICityRepository _cityRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IClimateRepository _climateRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IPassDiscountRepository _passDiscountRepository;
        private readonly IPassRepository _passRepository;
        private readonly ITourRepository _tourRepository;
        private readonly TravelCompanyDBContext _context;

        public UnitOfWork(ICityRepository cityRepository, IClientRepository clientRepository, IClimateRepository climateRepository,
            ICountryRepository countryRepository, IDiscountRepository discountRepository, IHotelRepository hotelRepository,
            IPassDiscountRepository passDiscountRepository, IPassRepository passRepository, ITourRepository tourRepository, TravelCompanyDBContext context)
        {
            _cityRepository = cityRepository;
            _clientRepository = clientRepository;
            _climateRepository = climateRepository;
            _countryRepository = countryRepository;
            _discountRepository = discountRepository;
            _hotelRepository = hotelRepository;
            _passDiscountRepository = passDiscountRepository;
            _passRepository = passRepository;
            _tourRepository = tourRepository;
            _context = context;
        }

        public IClientRepository ClientRepository => _clientRepository;

        public IClimateRepository ClimateRepository => _climateRepository;

        public ICountryRepository CountryRepository => _countryRepository;

        public IDiscountRepository DiscountRepository => _discountRepository;

        public ICityRepository CityRepository => _cityRepository;

        public IHotelRepository HotelRepository => _hotelRepository;

        public IPassDiscountRepository PassDiscountRepository => _passDiscountRepository;

        public IPassRepository PassRepository => _passRepository;

        public ITourRepository TourRepository => _tourRepository;

        public async Task Complete()
        {
            await _context.SaveChangesAsync();
        }
    }
}
