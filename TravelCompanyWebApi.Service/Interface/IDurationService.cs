using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IDurationService
    {
        Task AddDuration(Duration duration);
        Task DeleteDuration(byte id);
        Task<IEnumerable<Duration>> GetDurations();
        Task<Duration> GetDurationById(byte id);
        Task UpdateDuration(Duration duration);
    }
}
