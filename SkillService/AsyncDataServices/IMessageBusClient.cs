using SkillService.DTOs;

namespace SkillService.AsyncDataServices
{
	public interface IMessageBusClient
	{
		void PublishNewSkill(SkillPublishedDTO skillPublishedDTO);
		void Dispose();
	}
}
