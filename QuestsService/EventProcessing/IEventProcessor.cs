namespace QuestsService.EventProcessing
{
	public interface IEventProcessor
	{
		void ProcessEvent(string message);
	}
}
