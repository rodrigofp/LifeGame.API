using SkillService.DTOs;

namespace SkillService.SyncServices
{
	public interface IQuestClient
	{
		Task SendSkillToQuest(SkillReadDTO skill);
	}
}