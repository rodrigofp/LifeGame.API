using System.ComponentModel.DataAnnotations;

namespace SkillService.DTOs
{
	public class SkillCreateDTO 
	{
		public string Name { get; set; } = string.Empty;
		public int ExpInLevel { get; set; }
		public int LevelId { get; set; }
		public int UserId { get; set; }
	}
}