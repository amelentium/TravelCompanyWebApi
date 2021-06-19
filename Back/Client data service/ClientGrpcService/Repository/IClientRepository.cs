using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientGrpcService.Repository
{
    public interface IClientRepository
    {
        Task Add(ClientModel client);
        Task<ClientModel> Get(int id);
        Task<Clients> GetAll();
        Task Delete(int id);
        Task Update(ClientModel client);
    }
}
