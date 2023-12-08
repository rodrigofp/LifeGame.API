using QuestsService.Models;

namespace QuestsService.DTOs
{
	public class QuestCreateDTO
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Frequency { get; set; }
		public int ExpReward { get; set; }
		public int SkillId { get; set; }
	}
}
