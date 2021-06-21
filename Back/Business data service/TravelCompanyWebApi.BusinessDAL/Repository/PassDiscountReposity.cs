using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class PassDiscountRepository : GenericRepository<PassDiscount, int>, IPassDiscountRepository
    {
        public PassDiscountRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, config, "PassDiscounts") { }

        public async Task<IEnumerable<PassDiscount>> GetPassDiscountsByDiscountId(int discountId)
        {
            using var db = _connectionFactory.GetSqlConnection;
            return await db.QueryAsync<PassDiscount>("select * from " + _tableName + " where DiscountId = " + discountId);
        }

        public async Task<IEnumerable<PassDiscount>> GetPassDiscountsByPassId(int passId)
        {
            using var db = _connectionFactory.GetSqlConnection;
            return await db.QueryAsync<PassDiscount>("select * from " + _tableName + " where PassId = " + passId);
        }
    }
}
