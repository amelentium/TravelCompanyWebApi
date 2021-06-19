using System.Collections.Generic;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Repository.Repository.Interface
{
    public interface IPassDiscountRepository : IGenericRepository<PassDiscount, int>
    {
        IEnumerable<PassDiscount> GetPassDiscountsByPassId(int passId);
        IEnumerable<PassDiscount> GetPassDiscountsByDiscountId(int discountId);
    }
}
