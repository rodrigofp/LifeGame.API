using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utils
{
	public static class DatabaseConfiguration
	{
		public static void ConfigureDb<DB>(this IServiceCollection services, string connection)
			where DB : DbContext
		{
			services.AddDbContext<DB>(opt =>
			{
				opt.UseSqlServer(connection);
			});
		}
	}
}
