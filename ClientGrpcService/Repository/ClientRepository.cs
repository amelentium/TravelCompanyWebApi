using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientGrpcService.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoClient _client;
        private readonly IMongoCollection<ClientModel> _collection;
        public ClientRepository(IMongoClient client)
        {
            _client = client;
            _collection = client.GetDatabase("TravelCompany").GetCollection<ClientModel>("Clients");
        }
        public async Task Add(ClientModel client)
        {
            var id = await GetId();
            client.Id = ++id;

            await _collection.InsertOneAsync(client);
            await SetId(id);
        }

        public async Task Delete(int id)
        {
            await _collection.DeleteOneAsync(Builders<ClientModel>.Filter.Eq(c => c.Id, id));
        }

        public async Task<ClientModel> Get(int id)
        {
            return await _collection.FindAsync(Builders<ClientModel>.Filter.Eq(c => c.Id, id)).Result.FirstOrDefaultAsync();
        }

        public async Task<Clients> GetAll()
        {
            var clients = new Clients();

            foreach (var client in await _collection.FindAsync(_ => true).Result.ToListAsync())
                clients.Clients_.Add(client);

            return clients;
        }

        public async Task Update(ClientModel client)
        {
            await _collection.ReplaceOneAsync(c => c.Id.Equals(client.Id), client);
        }
        public async Task<int> GetId()
        {
            var data = await _client.GetDatabase("TravelCompany").GetCollection<BsonDocument>("EntityId").AsQueryable().ToListAsync();

            return data[0]["ClientId"].AsInt32;
        }

        public async Task SetId(int id)
        {
            var collection = _client.GetDatabase("TravelCompany").GetCollection<BsonDocument>("EntityId");

            var data = await collection.AsQueryable().ToListAsync();

            data[0]["ClientId"] = id;

            await collection.ReplaceOneAsync(Builders<BsonDocument>.Filter.Eq("_id", data[0]["_id"]), data[0].ToBsonDocument());
        }
    }
}
