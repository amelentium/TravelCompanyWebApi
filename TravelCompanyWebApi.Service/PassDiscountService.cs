using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class PassDiscountService : IPassDiscountService
    {
        private readonly IUnitOfWork _unit;
        private readonly IPassDiscountRepository _repository;

        public PassDiscountService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.PassDiscountRepository;
        }

        public async Task AddPassDiscount(PassDiscount passDiscount)
        {
            await _repository.Add(passDiscount);

            await _unit.Complete();
        }

        public async Task DeletePassDiscount(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<PassDiscount> GetPassDiscountById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<PassDiscount>> GetPassDiscounts()
        {
            return await _repository.Get();
        }

        public IEnumerable<PassDiscount> GetPassDiscountsByDiscountId(int discountId)
        {
            return _repository.GetPassDiscountsByDiscountId(discountId);
        }

        public IEnumerable<PassDiscount> GetPassDiscountsByPassId(int passId)
        {
            return _repository.GetPassDiscountsByPassId(passId);
        }

        public async Task UpdatePassDiscount(PassDiscount passDiscount)
        {
            _repository.Update(passDiscount);

            await _unit.Complete();
        }
    }
}
