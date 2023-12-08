namespace SkillService.DTOs
{
	public class SkillReadDTO 
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int ExpInLevel { get; set; }
		public LevelCurveReadDTO Level { get; set; } = new LevelCurveReadDTO();
		public int UserId { get; set; }
	}
}
