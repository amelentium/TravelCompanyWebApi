using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface IPassRepository : IGenericRepository<Pass>
    {
        IEnumerable<Pass> GetPassesByClientId(int clientId);
        IEnumerable<Pass> GetPassesByTourId(int tourId);
    }
}
