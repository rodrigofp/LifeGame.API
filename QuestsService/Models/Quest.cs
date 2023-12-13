namespace QuestsService.Models
{
	public class Quest : Entity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public Frequency Frequency { get; set; }
		public int ExpReward { get; set; }

		public int SkillId { get; set; }
		public Skill Skill { get; set; }

		public IEnumerable<QuestHistory> QuestHistories { get; set; }
	}

	public enum Frequency
	{
		Daily = 1,
		Weekly = 7,
		Monthly = 30
	}
}
