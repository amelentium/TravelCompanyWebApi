using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class DiscountService : IDiscountService
    {
        private readonly IUnitOfWork _unit;
        private readonly IDiscountRepository _repository;

        public DiscountService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.DiscountRepository;
        }

        public async Task AddDiscount(Discount discount)
        {
            await _repository.Add(discount);

            await _unit.Complete();
        }

        public async Task DeleteDiscount(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return await _repository.Get();
        }

        public async Task UpdateDiscount(Discount discount)
        {
            _repository.Update(discount);

            await _unit.Complete();
        }
    }
}
