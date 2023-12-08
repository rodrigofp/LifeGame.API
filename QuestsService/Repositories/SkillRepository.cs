using QuestsService.Data;
using QuestsService.Models;

namespace QuestsService.Repositories
{
	public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
	{
		public SkillRepository(QuestDbContext db) : base(db)
		{
		}

		public bool ExternalSkillIdExists(int externalId)
		{
			return _db.Skills.Any(s => s.ExternalId ==  externalId);
		}
	}
}
