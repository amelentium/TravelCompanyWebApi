using ClientGrpcService.Repository;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientGrpcService
{
    public class ClientService : Client.ClientBase
    {
        private readonly IClientRepository _repository;

        public ClientService(IClientRepository repository)
        {
            _repository = repository;
        }

        public async override Task<Empty> CreateClient(ClientModel client, ServerCallContext context)
        {
            await _repository.Add(client);

            return new Empty();
        }

        public async override Task<ClientModel> GetClient(IdRequest request, ServerCallContext context)
        {
            var result = await _repository.Get(request.Id);

            return result;
        }

        public async override Task<Clients> GetAllClients(Empty empty, ServerCallContext context)
        {
            var result = await _repository.GetAll();

            return result;
        }

        public async override Task<Empty> DeleteClient(IdRequest request, ServerCallContext context)
        {
            await _repository.Delete(request.Id);

            return new Empty();
        }

        public async override Task<Empty> UpdateClient(ClientModel client, ServerCallContext context)
        {
            await _repository.Update(client);

            return new Empty();
        }
    }
}
