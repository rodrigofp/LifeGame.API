using System.ComponentModel.DataAnnotations;

namespace SkillService.DTOs
{
	public class UserReadDTO
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
	}
}