using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using System.Text;

namespace RabbitMQServiceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        [HttpGet]
        public async Task<string> SendNumber(int number)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            await using var connection = await factory.CreateConnectionAsync();
            //Under one connection multiple channels can be created.
            await using var channel = await connection.CreateChannelAsync();
            //Using the created channel we are developing queue
            //Read all queue related properties by self
            await channel.QueueDeclareAsync(
                queue: "number_queue",
                durable: false,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var message = number.ToString();
            var body = Encoding.UTF8.GetBytes(message);

            await channel.BasicPublishAsync(
                exchange: "",
                routingKey: "number_queue",
                body: body);
            //Exclusivity if it is true then the connection it is declared that connection only can access queue, 
            //Same for Routing Key, the queue which has been declared will only can access that event
            return $"Number {number} sent to RabbitMQ!";
        }
    }
}
//Create connection mention rabbitMq server or localhost -> Declare connection -> create channel -> define queue properties -> pass json binding data -> 
