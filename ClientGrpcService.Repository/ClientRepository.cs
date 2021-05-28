using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientGrpcService.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<TEntity> _collection;
        public GenericRepository(IMongoClient client)
        {
            _client = client;
            _collection = client.GetDatabase("AeroportDb").GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public Task Add(ClientModel client)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ClientModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(ClientModel client, int id)
        {
            throw new NotImplementedException();
        }
    }
}
