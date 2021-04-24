using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Repository.Repository.Interface;
using TravelCompanyWebApi.Repository.UnitOfWork.Interface;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.Service
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unit;
        private readonly IClientRepository _repository;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unit = unitOfWork;
            _repository = _unit.ClientRepository;
        }

        public async Task AddClient(Client client)
        {
            await _repository.Add(client);

            await _unit.Complete();
        }

        public async Task DeleteClient(int id)
        {
            await _repository.Delete(id);

            await _unit.Complete();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<IEnumerable<Client>> GetClients()
        {
            return await _repository.Get();
        }

        public async Task UpdateClient(Client client)
        {
            _repository.Update(client);

            await _unit.Complete();
        }
    }
}
