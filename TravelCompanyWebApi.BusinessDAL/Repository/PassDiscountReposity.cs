using Microsoft.Extensions.Configuration;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class PassDiscountRepository : GenericRepository<PassDiscount, int>, IPassDiscountRepository
    {
        public PassDiscountRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, config, "PassDiscounts") { }
    }
}
