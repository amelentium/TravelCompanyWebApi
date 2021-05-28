using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TravelCompanyWebApi.BusinessBLL.Interface
{
    public interface IPassDiscountService
    {
        Task AddPassDiscount(PassDiscount pass);

        Task UpdatePassDiscount(PassDiscount pass, int Id);

        Task DeletePassDiscount(int Id);

        Task<PassDiscount> GetPassDiscountById(int Id);
        Task<IEnumerable<PassDiscount>> GetPassDiscountsByPassId(int passId);
        Task<IEnumerable<PassDiscount>> GetPassDiscountsByDiscountId(int discountId);

        Task<IEnumerable<PassDiscount>> GetAllPassDiscounts();
    }
}
