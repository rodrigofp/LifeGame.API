using RabbitMQ.Client;
using SkillService.DTOs;
using System.Text;
using System.Text.Json;

namespace SkillService.AsyncDataServices
{
	public class MessageBusClient : IMessageBusClient
	{
		private readonly IConnection _connection;
		private readonly IModel _channel;

		public MessageBusClient(IConfiguration configuration)
		{
			var factory = new ConnectionFactory()
			{
				HostName = configuration["RabbitMQHost"],
				Port = int.Parse(configuration["RabbitMQPort"])
			};
			try
			{
				_connection = factory.CreateConnection();
				_channel = _connection.CreateModel();

				_channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

				_connection.ConnectionShutdown += RabbitMQConnectionShutdown;

				Console.WriteLine("Connected to MessageBus");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error RabbitMQ: {ex.Message}");
			}
		}

		private void RabbitMQConnectionShutdown(object? sender, ShutdownEventArgs e)
		{
			Console.WriteLine("RabbitMQ shutting down");
		}

		public void PublishNewSkill(SkillPublishedDTO skillPublishedDTO)
		{
			var message = JsonSerializer.Serialize(skillPublishedDTO);

			if (_connection.IsOpen)
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

		public void Dispose()
		{
			if (_channel.IsOpen)
			{
				_channel.Close();
				_connection.Close();
			}
		}
	}
}
