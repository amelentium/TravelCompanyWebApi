using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class DiscountRepository : GenericRepository<Discount, int>, IDiscountRepository
    {
        public DiscountRepository(TravelCompanyDBContext context) : base(context) { }
    }
}
