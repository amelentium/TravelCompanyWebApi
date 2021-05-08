using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        public CityRepository(TravelCompanyDBContext context) : base(context) { }

        public IEnumerable<City> GetCitiesByClimateId(int climateId)
        {
            return _set.Where(c => c.ClimateId == climateId).AsEnumerable();
        }

        public IEnumerable<City> GetCitiesByCountryId(int countryId)
        {
            return _set.Where(c => c.CountryId == countryId).AsEnumerable();
        }
    }
}
