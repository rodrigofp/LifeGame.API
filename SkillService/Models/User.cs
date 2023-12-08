namespace SkillService.Models
{
	public class User : Entity
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public IEnumerable<Skill> Skills { get; set; }
	}
}
