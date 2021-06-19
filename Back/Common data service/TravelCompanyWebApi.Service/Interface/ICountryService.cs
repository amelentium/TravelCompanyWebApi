using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface ICountryService
    {
        Task AddCountry(Country country);
        Task DeleteCountry(int id);
        Task<IEnumerable<Country>> GetCountries();
        Task<Country> GetCountryById(int id);
        Task UpdateCountry(Country country);
    }
}
