using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repositories.Interfaces;

namespace TravelCompanyWebApi.BusinessDAL.Repository.Interface
{
    public interface IPassDiscountRepository : IGenericRepository<PassDiscount, int>
    {
        Task<IEnumerable<PassDiscount>> GetPassDiscountsByPassId(int passId);
        Task<IEnumerable<PassDiscount>> GetPassDiscountsByDiscountId(int discountId);
    }
}
