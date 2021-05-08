using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IPassDiscountService
    {
        Task AddPassDiscount(PassDiscount discount);
        Task DeletePassDiscount(int id);
        Task<IEnumerable<PassDiscount>> GetPassDiscounts();
        Task<PassDiscount> GetPassDiscountById(int id);
        IEnumerable<PassDiscount> GetPassDiscountsByPassId(int passId);
        IEnumerable<PassDiscount> GetPassDiscountsByDiscountId(int discountId);
        Task UpdatePassDiscount(PassDiscount discount);
    }
}
