using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class PassRepository : GenericRepository<Pass, int>, IPassRepository
    {
        public PassRepository(IConnectionFactory connectionFactory, IConfiguration config) : base (connectionFactory, config, "Passes") { }

        public async Task<IEnumerable<Pass>> GetPassesByClientId(int clientId)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<Pass>("select * from " + _tableName + " where ClientId = " + clientId);
            }
        }

        public async Task<IEnumerable<Pass>> GetPassesByTourId(int tourId)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<Pass>("select * from " + _tableName + " where TourId = " + tourId);
            }
        }
    }
}
