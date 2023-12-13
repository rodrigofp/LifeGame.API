using Core.MessageBus.DTOs;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Core.MessageBus
{
	public class MessageBus : IMessageBus
	{
		private readonly ConnectionFactory _factory;
		private IConnection _connection;
		private IModel _channel;

		public MessageBus(IConfiguration configuration)
		{
			_factory = new ConnectionFactory()
			{
				HostName = configuration["RabbitMQHost"],
				Port = int.Parse(configuration["RabbitMQPort"])
			};
		}

		private void Connect(string exchange)
		{
			try
			{
				_connection = _factory.CreateConnection();
				_channel = _connection.CreateModel();

				_channel.ExchangeDeclare(exchange: exchange, type: ExchangeType.Fanout);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error RabbitMQ: {ex.Message}");
			}
		}

		public void Dispose()
		{
			if (_channel?.IsOpen ?? false)
			{
				_channel.Close();
				_connection.Close();
			}
		}

		public void PublishNewMessage(EventDTO eventDTO)
		{
			if (!_connection?.IsOpen ?? true)
				Connect(eventDTO.GetExchange());

			var message = JsonSerializer.Serialize(eventDTO);

			SendMessage(message);
		}

		private void SendMessage(string message)
		{
			var body = Encoding.UTF8.GetBytes(message);

			_channel.BasicPublish(
				exchange: "trigger",
				routingKey: "",
				basicProperties: null,
				body: body);

		}
	}
}
