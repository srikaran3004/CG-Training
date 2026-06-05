using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CubeWorkerAPI.Services
{
    public class CubeWorker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            channel.QueueDeclare(
                queue: "cube_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            Console.WriteLine("Cube Worker Started. Waiting for messages...");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                int number = int.Parse(message);
                int cube = number * number * number;

                // Debug Logs
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"Received number: {number}");
                Console.WriteLine($"Cube result: {cube}");
                Console.WriteLine($"CorrelationId: {ea.BasicProperties.CorrelationId}");
                Console.WriteLine("---------------------------------");

                var response = cube.ToString();
                var responseBytes = Encoding.UTF8.GetBytes(response);

                var props = channel.CreateBasicProperties();
                props.CorrelationId = ea.BasicProperties.CorrelationId;

                channel.BasicPublish(
                    exchange: "",
                    routingKey: ea.BasicProperties.ReplyTo,
                    basicProperties: props,
                    body: responseBytes);
            };

            channel.BasicConsume(
                queue: "cube_queue",
                autoAck: true,
                consumer: consumer);

            try
            {
                await Task.Delay(Timeout.Infinite, stoppingToken);
            }
            catch (OperationCanceledException)
            {
            }
            finally
            {
                channel.Close();
                connection.Close();
                channel.Dispose();
                connection.Dispose();
            }
        }
    }
}