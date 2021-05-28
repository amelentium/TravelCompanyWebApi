using Microsoft.Extensions.Configuration;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Infrastructure;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessDAL.Repository
{
    public class DiscountRepository : GenericRepository<Discount, int>, IDiscountRepository
    {
        public DiscountRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, config, "Discounts") { }
    }
}
