namespace QuestsService.DTOs
{
	public class QuestReadDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Frequency { get; set; }
		public int ExpReward { get; set; }
		public SkillReadDTO Skill { get; set; }
	}
}
