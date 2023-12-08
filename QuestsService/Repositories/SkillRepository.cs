using QuestsService.Data;
using QuestsService.Models;

namespace QuestsService.Repositories
{
	public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
	{
		public SkillRepository(QuestDbContext db) : base(db)
		{
		}
	}
}
