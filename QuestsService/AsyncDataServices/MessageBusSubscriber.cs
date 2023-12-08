﻿
using QuestsService.EventProcessing;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace QuestsService.AsyncDataServices
{
	public class MessageBusSubscriber : BackgroundService
	{
		private readonly IEventProcessor _eventProcessor;
		private IConnection _connection;
		private IModel _channel;
		private string _queueName;

		public MessageBusSubscriber(IConfiguration configuration, IEventProcessor eventProcessor)
		{
			_eventProcessor = eventProcessor;
			InitializeRabbitMQ(configuration);
		}

		private void InitializeRabbitMQ(IConfiguration configuration)
		{
			var factory = new ConnectionFactory()
			{
				HostName = configuration["RabbitMQHost"],
				Port = int.Parse(configuration["RabbitMQPort"])
			};

			_connection = factory.CreateConnection();
			_channel = _connection.CreateModel();
			_channel.ExchangeDeclare(
				exchange: "trigger",
				type: ExchangeType.Fanout);

			_queueName = _channel.QueueDeclare().QueueName;
			_channel.QueueBind(
				queue: _queueName,
				exchange: "trigger",
				routingKey: "");
		}

		protected override Task ExecuteAsync(CancellationToken stoppingToken)
		{
			stoppingToken.ThrowIfCancellationRequested();

			var consumer = new EventingBasicConsumer(_channel);

			consumer.Received += (ModuleHandle, ea) =>
			{
				var body = ea.Body;
				var notificationMessage = Encoding.UTF8.GetString(body.ToArray());

				_eventProcessor.ProcessEvent(notificationMessage);
			};

			_channel.BasicConsume(
				queue: _queueName,
				autoAck: true,
				consumer: consumer);

			return Task.CompletedTask;
		}

		public override void Dispose()
		{
			if (_channel.IsOpen)
			{
				_channel.Close();
				_connection.Close();
			}
			base.Dispose();
		}
	}
}