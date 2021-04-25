using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface ICityService
    {
        Task AddCity(City city);
        Task DeleteCity(int id);
        Task<IEnumerable<City>> GetCities();
        Task<City> GetCityById(int id);
        Task<IEnumerable<City>> GetCitiesByCountryId(int countryId);
        Task<IEnumerable<City>> GetCitiesByClimateId(int climateId);
        Task UpdateCity(City city);
    }
}
