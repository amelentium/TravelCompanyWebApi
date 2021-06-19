using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IDiscountService
    {
        Task AddDiscount(Discount discount);
        Task DeleteDiscount(int id);
        Task<IEnumerable<Discount>> GetDiscounts();
        Task<Discount> GetDiscountById(int id);
        Task UpdateDiscount(Discount discount);
    }
}
