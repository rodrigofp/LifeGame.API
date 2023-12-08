namespace QuestsService.DTOs
{
	public class QuestHistoryReadDTO
	{
		public int Id { get; set; }
		public string Quest { get; set; }
		public int ExpReward { get; set; }
		public string Skill { get; set; }
		public DateTime DateCompleted { get; set; }
	}
}
