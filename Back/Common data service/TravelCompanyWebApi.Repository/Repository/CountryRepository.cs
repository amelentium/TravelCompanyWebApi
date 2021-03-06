using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class CountryRepository : GenericRepository<Country, int>, ICountryRepository
    {
        public CountryRepository(TravelCompanyDBContext context) : base(context) { }
    }
}
