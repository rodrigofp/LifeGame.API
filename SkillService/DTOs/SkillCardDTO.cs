namespace SkillService.DTOs
{
	public class SkillCardDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int CurrentLevel { get; set; }
		public int ExpInLevel { get; set; }
		public int ExpToNextLevel { get; set; }
		public decimal PercentageToLevelUp { get => ((decimal)ExpInLevel * 100) / ExpToNextLevel; }
	}
}
