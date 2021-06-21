using System;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TravelCompanyWebApi.CQRS.Clients.Commands;
using TravelCompanyWebApi.Infrastructure.Entity;
using TravelCompanyWebApi.Service.Interface;

namespace TravelCompanyWebApi.MessageHandlers
{
    public class ClientMessageHandler : BackgroundService
    {
        private readonly IServiceProvider _sp;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public ClientMessageHandler(IServiceProvider sp)
        {
            _sp = sp;

            var factory = new ConnectionFactory
                {HostName = "localhost", UserName = "guest", Password = "guest", VirtualHost = "/", Port = 5672};

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();

            _channel.QueueDeclare(
                queue: "clientsQueue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (stoppingToken.IsCancellationRequested)
            {
                _channel.Dispose();
                _connection.Dispose();
                return;
            }

            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (model, ea) =>
            {
                var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                var client = JsonSerializer.Deserialize<Client>(message);

                using var scope = _sp.CreateScope();
                var service = scope.ServiceProvider.GetRequiredService<IClientService>();

                switch (ea.RoutingKey)
                {
                    case "create":
                        client!.Id = 0;
                        await service.AddClient(client);
                        break;
                    case "delete":
                        await service.DeleteClient(client!.Id);
                        break;
                    case "update":
                        await service.UpdateClient(client);
                        break;
                }
            };

            _channel.BasicConsume(queue: "clientsQueue", autoAck: true, consumer: consumer);
        }
    }
}
