using SkillService.Data;
using SkillService.Models;

namespace SkillService.Repositories
{
	public class UserRepository : RepositoryBase<User>, IUserRepository
	{
		public UserRepository(SkillDbContext db) : base(db)
		{
		}
	}
}
