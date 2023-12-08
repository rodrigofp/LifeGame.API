using QuestsService.Data;
using QuestsService.Models;

namespace QuestsService.Repositories
{
	public class QuestHistoryRepository : RepositoryBase<QuestHistory>, IQuestHistoryRepository
	{
		public QuestHistoryRepository(QuestDbContext db) : base(db)
		{
		}
	}
}
