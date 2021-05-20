using ClientGrpcService.Repository;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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

            //var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest", VirtualHost = "/", Port = 5672};

            //using (var connection = factory.CreateConnection())
            //using (var channel = connection.CreateModel())
            //{
            //    channel.QueueDeclare(queue: "clientsQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            //    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(client));

            //    channel.BasicPublish(exchange: "", routingKey: "clients", basicProperties: null, body: body);
            //}

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
