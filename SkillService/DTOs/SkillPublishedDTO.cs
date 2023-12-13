using Core.MessageBus.DTOs;

namespace SkillService.DTOs
{
	public class SkillPublishedDTO : EventDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public override string Event { get => "Skill_Published"; }

		public override string GetExchange()
		{
			return "Skill";
		}
	}
}
