namespace SkillService.Models
{
	public class Skill : Entity
	{
		public string Name { get; set; }
		public int ExpInLevel { get; set; }

		public int LevelId { get; set; }
		public LevelCurve Level { get; set; }

		public int UserId { get; set; }
        public User User { get; set; }

	}
}
