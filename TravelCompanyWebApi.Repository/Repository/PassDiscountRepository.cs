using System.Collections.Generic;
using System.Linq;
using TravelCompanyWebApi.Infrastructure.Context;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;

namespace TravelCompanyWebApi.Repository.Repository
{
    public class PassDiscountRepository : GenericRepository<PassDiscount>, IPassDiscountRepository
    {
        public PassDiscountRepository(TravelCompanyDBContext context) : base(context) { }

        public IEnumerable<PassDiscount> GetPassDiscountsByDiscountId(int discountId)
        {
            return _set.Where(pd => pd.DiscountId == discountId).AsEnumerable();
        }

        public IEnumerable<PassDiscount> GetPassDiscountsByPassId(int passId)
        {
            return _set.Where(pd => pd.PassId == passId).AsEnumerable();
        }
    }
}
