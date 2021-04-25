using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IClimateService
    {
        Task AddClimate(Climate climate);
        Task DeleteClimate(int id);
        Task<IEnumerable<Climate>> GetClimates();
        Task<Climate> GetClimateById(int id);
        Task UpdateClimate(Climate climate);
    }
}
