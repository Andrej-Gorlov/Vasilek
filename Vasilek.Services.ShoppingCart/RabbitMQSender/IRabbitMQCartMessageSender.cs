using Vasilek.MessageBus;

namespace Vasilek.Services.ShoppingCart.RabbitMQSender
{
    public interface IRabbitMQCartMessageSender
    {
                        // отправляемое message  и   name очереди
        void SendMessage(BaseMessage baseMessage, String queueName);
    }
}
