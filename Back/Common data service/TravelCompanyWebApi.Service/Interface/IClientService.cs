using System.Collections.Generic;
using System.Threading.Tasks;
using TravelCompanyWebApi.Infrastructure.Entity;

namespace TravelCompanyWebApi.Service.Interface
{
    public interface IClientService
    {
        Task AddClient(Client client);
        Task DeleteClient(int id);
        Task<IEnumerable<Client>> GetClients();
        Task<Client> GetClientById(int id);
        Task UpdateClient(Client client);
    }
}
