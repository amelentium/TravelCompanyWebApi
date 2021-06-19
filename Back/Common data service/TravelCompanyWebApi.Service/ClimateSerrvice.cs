using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class ClimateService : IClimateService
    {
        private readonly IUnitOfWork _unit;
        private readonly IClimateRepository _repository;

        public ClimateService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.ClimateRepository;
        }

        public async Task AddClimate(Climate climate)
        {
            await _repository.Add(climate);

            await _unit.Complete();
        }

        public async Task DeleteClimate(byte id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Climate> GetClimateById(byte id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Climate>> GetClimates()
        {
            return await _repository.Get();
        }

        public async Task UpdateClimate(Climate climate)
        {
            _repository.Update(climate);

            await _unit.Complete();
        }
    }
}
