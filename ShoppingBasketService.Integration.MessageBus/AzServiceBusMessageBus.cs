using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Core;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ShoppingBasketService.Integration.Messages;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBasketService.Integration.MessageBus
{
    public class AzServiceBusMessageBus : IMessageBus
    {
        private readonly IConfiguration _configuration;

        public AzServiceBusMessageBus(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            ISenderClient topicClient = new TopicClient(_configuration["Azure:ServiceBusConnection"], topicName);

            var jsonMessage = JsonConvert.SerializeObject(message);
            var serviceBusMessage = new Message(Encoding.UTF8.GetBytes(jsonMessage))
            {
                CorrelationId = Guid.NewGuid().ToString()
            };

            await topicClient.SendAsync(serviceBusMessage);
            Console.WriteLine($"Sent message to {topicClient.Path}");
            await topicClient.CloseAsync();

        }
    }
}
