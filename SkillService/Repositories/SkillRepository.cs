using SkillService.Data;
using SkillService.Models;

namespace SkillService.Repositories
{
	public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
	{
		public SkillRepository(SkillDbContext db) : base(db)
		{
		}
	}
}
