using QuestsService.Data;
using QuestsService.Models;

namespace QuestsService.Repositories
{
	public class QuestRepository : RepositoryBase<Quest>, IQuestRepository
	{
		public QuestRepository(QuestDbContext db) : base(db)
		{
		}
	}
}
