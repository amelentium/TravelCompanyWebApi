using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        Task<IEnumerable<Pass>> GetPassesByClientId(int clientId);
        Task<IEnumerable<Pass>> GetPassesByTourId(int tourId);
        Task UpdatePass(Pass pass);
    }
}
