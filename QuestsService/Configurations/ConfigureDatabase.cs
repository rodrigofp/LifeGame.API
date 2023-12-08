using Microsoft.EntityFrameworkCore;
using QuestsService.Data;

namespace QuestsService.Configurations
{
	public static class ConfigureDatabase
	{
		public static void ConfigureDb(this IServiceCollection services, string connection)
		{
			services.AddDbContext<QuestDbContext>(opt =>
			{
				opt.UseSqlServer(connection);
			});
		}
	}
}
