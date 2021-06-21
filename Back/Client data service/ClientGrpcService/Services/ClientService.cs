using ClientGrpcService.Repository;
using Grpc.Core;
using RabbitMQ.Client;
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

        public override async Task<Empty> CreateClient(ClientModel client, ServerCallContext context)
        {
            await _repository.Add(client);

            SendMessage(client, "create");

            return new Empty();
        }

        public override async Task<ClientModel> GetClient(IdRequest request, ServerCallContext context)
        {
            var result = await _repository.Get(request.Id);

            return result;
        }

        public override async Task<Clients> GetAllClients(Empty empty, ServerCallContext context)
        {
            var result = await _repository.GetAll();

            return result;
        }

        public override async Task<Empty> DeleteClient(IdRequest request, ServerCallContext context)
        {
            await _repository.Delete(request.Id);

            SendMessage(new ClientModel {Id = request.Id}, "delete");

            return new Empty();
        }

        public override async Task<Empty> UpdateClient(ClientModel client, ServerCallContext context)
        {
            await _repository.Update(client);

            SendMessage(client, "update");

            return new Empty();
        }

        private static void SendMessage(ClientModel client, string routingKey)
        {
            var factory = new ConnectionFactory{HostName = "localhost", UserName = "guest", Password = "guest", VirtualHost = "/", Port = 5672};

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "clientsQueue", durable: false, exclusive: false, autoDelete: false,
                arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(client));

            channel.BasicPublish(exchange: "clientsExchange", routingKey: routingKey, basicProperties: null, body: body);

        }
    }
}
