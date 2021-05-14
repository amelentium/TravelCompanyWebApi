using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface ICityRepository : IGenericRepository<City, int>
    {
        IEnumerable<City> GetCitiesByCountryId(int countryId);
        IEnumerable<City> GetCitiesByClimateId(byte climateId);
    }
}
