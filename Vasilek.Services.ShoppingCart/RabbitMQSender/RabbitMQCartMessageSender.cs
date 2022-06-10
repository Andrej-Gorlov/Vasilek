using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using Vasilek.MessageBus;

namespace Vasilek.Services.ShoppingCart.RabbitMQSender
{
    public class RabbitMQCartMessageSender : IRabbitMQCartMessageSender
    {
        private readonly string? _hostname;
        private readonly string? _password;
        private readonly string? _username;
        private IConnection _connection;

        public RabbitMQCartMessageSender()
        {
            _hostname = "localhost";
            _password = "guest";
            _username = "guest";
        }
        public void SendMessage(BaseMessage message, string queueName)
        {
            if (ConnectionExists())
            {
                using var channel = _connection.CreateModel(); // create new канал
                // durable: time существования queue (сохранится ли queue после перезапуска сервера с rabbitmq)
                // exclusive: эксклюзивная queue
                // autoDelete:
                // arguments: null (дополнительные arguments)
                channel.QueueDeclare(queue: queueName, false, false, false, arguments: null);// настройка канала (queue)
                var json = JsonConvert.SerializeObject(message);
                var body = Encoding.UTF8.GetBytes(json);
                // отправка message
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            }
        }

        // create соединения и канал для передачи message
        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception)
            {
                //log exception
            }
        }
        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }
            CreateConnection();
            return _connection != null;
        }
    }
}
