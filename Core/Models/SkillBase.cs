using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
	public abstract class SkillBase : Entity
	{
		public string Name { get; set; }
	}
}