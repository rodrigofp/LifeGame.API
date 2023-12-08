using SkillService.Data;
using SkillService.Models;

namespace SkillService.Repositories
{
	public class LevelCurveRepository : RepositoryBase<LevelCurve>, ILevelCurveRepository
	{
		public LevelCurveRepository(SkillDbContext db) : base(db)
		{
		}
	}
}
