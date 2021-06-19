using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IPassService
    {
        Task AddPass(Pass pass);
        Task DeletePass(int id);
        Task<IEnumerable<Pass>> GetPasses();
        Task<Pass> GetPassById(int id);
        IEnumerable<Pass> GetPassesByClientId(int clientId);
        IEnumerable<Pass> GetPassesByTourId(int tourId);
        Task UpdatePass(Pass pass);
    }
}
