using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.BusinessBLL.Interface;
using TravelCompanyWebApi.BusinessDAL.Entity;
using TravelCompanyWebApi.BusinessDAL.Repository.Interface;

namespace TravelCompanyWebApi.BusinessBLL
{
    public class PassDiscountService : IPassDiscountService
    {
        IUnitOfWork _unitOfWork;
        public PassDiscountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddPassDiscount(PassDiscount passDiscount)
        {
            await _unitOfWork.PassDiscountRepository.Add(passDiscount);
        }

        public async Task DeletePassDiscount(int Id)
        {
            await _unitOfWork.PassDiscountRepository.Delete(Id);
        }

        public async Task<IEnumerable<PassDiscount>> GetAllPassDiscounts()
        {
            return await _unitOfWork.PassDiscountRepository.GetAll();
        }

        public async Task<PassDiscount> GetPassDiscountById(int Id)
        {
            return await _unitOfWork.PassDiscountRepository.Get(Id);
        }

        public async Task<IEnumerable<PassDiscount>> GetPassDiscountsByDiscountId(int discountId)
        {
            return await _unitOfWork.PassDiscountRepository.GetPassDiscountsByDiscountId(discountId);
        }

        public async Task<IEnumerable<PassDiscount>> GetPassDiscountsByPassId(int passId)
        {
            return await _unitOfWork.PassDiscountRepository.GetPassDiscountsByPassId(passId);
        }

        public async Task UpdatePassDiscount(PassDiscount passDiscount, int Id)
        {
            await _unitOfWork.PassDiscountRepository.Update(passDiscount, Id);
        }
    }
}
