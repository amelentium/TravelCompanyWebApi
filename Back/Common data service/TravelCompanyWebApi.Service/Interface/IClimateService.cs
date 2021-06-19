using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IClimateService
    {
        Task AddClimate(Climate climate);
        Task DeleteClimate(byte id);
        Task<IEnumerable<Climate>> GetClimates();
        Task<Climate> GetClimateById(byte id);
        Task UpdateClimate(Climate climate);
    }
}
