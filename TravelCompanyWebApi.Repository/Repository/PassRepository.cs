using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class PassRepository : GenericRepository<Pass, int>, IPassRepository
    {
        public PassRepository(TravelCompanyDBContext context) : base(context) { }

        public IEnumerable<Pass> GetPassesByClientId(int clientId)
        {
            return _set.Where(p => p.ClientId == clientId).AsEnumerable();
        }

        public IEnumerable<Pass> GetPassesByTourId(int tourId)
        {
            return _set.Where(p => p.TourId == tourId).AsEnumerable();
        }
    }
}
