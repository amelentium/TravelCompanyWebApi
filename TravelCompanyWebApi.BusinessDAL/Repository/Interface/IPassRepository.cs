using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces;

namespace TravelCompanyWebApi.BusinessDAL.Repository.Interface
{
    public interface IPassRepository : IGenericRepository<Pass, int>
    {
        Task<IEnumerable<Pass>> GetPassesByClientId(int clientId);
        Task<IEnumerable<Pass>> GetPassesByTourId(int tourId);
    }
}
