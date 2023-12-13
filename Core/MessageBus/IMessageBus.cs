using Core.MessageBus.DTOs;

namespace Core.MessageBus
{
	public interface IMessageBus
	{
		void PublishNewMessage(EventDTO eventDTO);
		void Dispose();
	}
}
