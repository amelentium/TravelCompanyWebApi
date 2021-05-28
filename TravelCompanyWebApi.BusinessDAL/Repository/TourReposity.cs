using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class TourRepository : GenericRepository<Tour, int>, ITourRepository
    {
        public TourRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, config, "Tours") { }

        public async Task<IEnumerable<Tour>> GetToursByDurationId(int durationId)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<Tour>("select * from " + _tableName + " where DurationId = " + durationId);
            }
        }

        public async Task<IEnumerable<Tour>> GetToursByHotelId(int hotelId)
        {
            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<Tour>("select * from " + _tableName + " where HotelId = " + hotelId);
            }
        }
    }
}
