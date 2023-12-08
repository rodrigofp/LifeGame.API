using Microsoft.EntityFrameworkCore;
using SkillService.Data;

namespace SkillService.Configurations
{
	public static class DatabaseConfiguration
	{
		public static void ConfigureDb(this IServiceCollection services, string connection)
		{
			services.AddDbContext<SkillDbContext>(opt =>
			{
				opt.UseSqlServer(connection);
			});
		}
	}
}
