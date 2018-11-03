using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Text;

namespace logging_service
{
    class logging_service
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: "order_exchange",
                                        type: "direct",
                                        durable: true);

                var queueName = channel.QueueDeclare("logging_queue").QueueName;

                channel.QueueBind(queue: queueName,
                                     exchange: "order_exchange",
                                     routingKey: "create_order");

                Console.WriteLine(" [*] Waiting for logging_queue.");
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {

                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine(" [x] {0}", message);
                    string path = @".\log.txt";
                    if (!File.Exists(path))
                    {
                        File.WriteAllText(path, $"Log: {message}" + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(path, $"Log: {message}" + Environment.NewLine);
                    }
                };
                channel.BasicConsume(queue: queueName,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
