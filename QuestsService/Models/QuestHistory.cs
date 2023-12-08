namespace QuestsService.Models
{
	public class QuestHistory : Entity
	{
		public int QuestId { get; set; }
		public Quest Quest { get; set; }
		public DateTime DateCompleted { get; set; } = DateTime.Today;
	}
}