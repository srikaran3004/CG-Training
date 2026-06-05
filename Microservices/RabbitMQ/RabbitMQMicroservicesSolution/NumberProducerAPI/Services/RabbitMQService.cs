using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Collections.Concurrent;

namespace NumberProducerAPI.Services
{
    public class RabbitMQRPCClient : IDisposable
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly string replyQueueName;
        private readonly EventingBasicConsumer consumer;

        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> callbackMapper =
            new ConcurrentDictionary<string, TaskCompletionSource<string>>();

        public RabbitMQRPCClient()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            connection = factory.CreateConnection();
            channel = connection.CreateModel();

            replyQueueName = channel.QueueDeclare().QueueName;

            consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                if (!callbackMapper.TryRemove(ea.BasicProperties.CorrelationId, out var tcs))
                    return;

                var body = ea.Body.ToArray();
                var response = Encoding.UTF8.GetString(body);

                tcs.SetResult(response);
            };

            channel.BasicConsume(
                consumer: consumer,
                queue: replyQueueName,
                autoAck: true);
        }

        public async Task<string> CallAsync(string queueName, string message, CancellationToken cancellationToken = default)
        {
            var correlationId = Guid.NewGuid().ToString();

            var props = channel.CreateBasicProperties();
            props.CorrelationId = correlationId;
            props.ReplyTo = replyQueueName;

            var messageBytes = Encoding.UTF8.GetBytes(message);

            var tcs = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);

            callbackMapper.TryAdd(correlationId, tcs);

            channel.BasicPublish(
                exchange: "",
                routingKey: queueName,
                basicProperties: props,
                body: messageBytes);

            using var timeoutCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
            timeoutCts.CancelAfter(TimeSpan.FromSeconds(15));

            try
            {
                await Task.Delay(Timeout.InfiniteTimeSpan, timeoutCts.Token);
            }
            catch (OperationCanceledException)
            {
                if (tcs.Task.IsCompleted)
                {
                    return await tcs.Task;
                }

                callbackMapper.TryRemove(correlationId, out _);

                if (cancellationToken.IsCancellationRequested)
                {
                    throw;
                }

                throw new TimeoutException("Timed out waiting for RabbitMQ response.");
            }

            return await tcs.Task;
        }

        public void Dispose()
        {
            channel?.Dispose();
            connection?.Dispose();
        }
    }
}