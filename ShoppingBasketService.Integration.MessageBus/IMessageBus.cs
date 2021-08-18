using ShoppingBasketService.Integration.Messages;
using System.Threading.Tasks;

namespace ShoppingBasketService.Integration.MessageBus
{
    public interface IMessageBus
    {
        Task PublishMessage (IntegrationBaseMessage message, string topicName);
    }
}
