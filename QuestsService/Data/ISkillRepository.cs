using QuestsService.Models;

namespace QuestsService.Data
{
	public interface ISkillRepository : IRepository<Skill> 
	{
		bool ExternalSkillIdExists(int externalId);
	}
}
