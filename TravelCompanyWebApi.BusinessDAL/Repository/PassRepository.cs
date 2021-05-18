using Microsoft.Extensions.Configuration;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class PassRepository : GenericRepository<Pass, int>, IPassRepository
    {
        public PassRepository(IConnectionFactory connectionFactory, IConfiguration config) : base (connectionFactory, config, "Passes") { }
    }
}
