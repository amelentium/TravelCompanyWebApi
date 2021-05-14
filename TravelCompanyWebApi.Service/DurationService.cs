using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class DurationService : IDurationService
    {
        private readonly IUnitOfWork _unit;
        private readonly IDurationRepository _repository;

        public DurationService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.DurationRepository;
        }

        public async Task AddDuration(Duration duration)
        {
            await _repository.Add(duration);

            await _unit.Complete();
        }

        public async Task DeleteDuration(byte id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Duration> GetDurationById(byte id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Duration>> GetDurations()
        {
            return await _repository.Get();
        }

        public async Task UpdateDuration(Duration duration)
        {
            _repository.Update(duration);

            await _unit.Complete();
        }
    }
}
