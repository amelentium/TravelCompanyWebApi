using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class PassService : IPassService
    {
        private readonly IUnitOfWork _unit;
        private readonly IPassRepository _repository;

        public PassService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.PassRepository;
        }

        public async Task AddPass(Pass pass)
        {
            await _repository.Add(pass);

            await _unit.Complete();
        }

        public async Task DeletePass(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Pass> GetPassById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Pass>> GetPasses()
        {
            return await _repository.Get();
        }

        public IEnumerable<Pass> GetPassesByClientId(int clientId)
        {
            return _repository.GetPassesByClientId(clientId);
        }

        public IEnumerable<Pass> GetPassesByTourId(int tourId)
        {
            return _repository.GetPassesByTourId(tourId);
        }

        public async Task UpdatePass(Pass pass)
        {
            _repository.Update(pass);

            await _unit.Complete();
        }
    }
}
