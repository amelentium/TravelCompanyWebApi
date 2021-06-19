using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;

namespace TravelCompanyWebApi.BusinessBLL.Interface
{
    public interface IDiscountService
    {
        Task AddDiscount(Discount pass);

        Task UpdateDiscount(Discount pass, int Id);

        Task DeleteDiscount(int Id);

        Task<Discount> GetDiscountById(int Id);

        Task<IEnumerable<Discount>> GetAllDiscounts();
    }
}
