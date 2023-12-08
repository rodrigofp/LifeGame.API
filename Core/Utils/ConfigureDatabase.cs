using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utils
{
	public static class ConfigureDatabase
	{
		public static void ConfigureDb<DB>(this IServiceCollection services, string connection, bool isProduction)
			where DB : DbContext
		{
			if (isProduction)
				services.AddDbContext<DB>(opt =>
				{
					opt.UseSqlServer(connection);
				});

			else
				services.AddDbContext<DB>(opt =>
				{
					opt.UseInMemoryDatabase("InMem");
				});
		}
	}
}
