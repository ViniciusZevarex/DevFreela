using DevFreela.Core.Services;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;

        public MessageBusService(IConfiguration configuration)
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public void Publish(string queue, byte[] message)
        {
            using(var connection = _factory.CreateConnection())
            {
                using(var chanel = connection.CreateModel())
                {
                    //Garantir que a fila esteja criada
                    chanel.QueueDeclare(
                            queue:queue,
                            durable:false,
                            exclusive:false,
                            autoDelete:false,
                            arguments: null);

                    chanel.BasicPublish(
                            exchange:"",
                            routingKey:queue,
                            basicProperties: null,
                            body:message);
                }
            }
        }
    }
}
