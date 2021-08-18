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
        public async Task PublishMessage(IntegrationBaseMessage message, string topicName)
        {
            var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{envName}.json", optional: false)
                .Build();

            ISenderClient topicClient = new TopicClient(configuration["Azure:ServiceBusConnection"], topicName);

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
