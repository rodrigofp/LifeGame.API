namespace Core.MessageBus.DTOs
{
	public abstract class EventDTO
	{
		public abstract string Event { get; }

		public abstract string GetExchange();
	}
}
