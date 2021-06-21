using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessBLL
{
    public class DiscountService : IDiscountService
    {
        readonly IUnitOfWork _unitOfWork;
        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddDiscount(Discount discount)
        {
            await _unitOfWork.DiscountRepository.Add(discount);
        }

        public async Task DeleteDiscount(int Id)
        {
            await _unitOfWork.DiscountRepository.Delete(Id);
        }

        public async Task<IEnumerable<Discount>> GetAllDiscounts()
        {
            return await _unitOfWork.DiscountRepository.GetAll();
        }

        public async Task<Discount> GetDiscountById(int Id)
        {
            return await _unitOfWork.DiscountRepository.Get(Id);
        }

        public async Task UpdateDiscount(Discount discount, int Id)
        {
            await _unitOfWork.DiscountRepository.Update(discount, Id);
        }
    }
}
