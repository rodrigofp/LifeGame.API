using Microsoft.EntityFrameworkCore;
using QuestsService.Models;

namespace QuestsService.Data
{
	public static class SeedDb
	{
		public static void Seed(this WebApplication app)
		{
			using var serviceScope = app.Services.CreateScope();
			var db = serviceScope.ServiceProvider.GetRequiredService<QuestDbContext>();

			Migrate(db);

			SeedData(db);
		}

		private static void SeedData(QuestDbContext db)
		{
			SeedUser(db.Users);
		}

		private static void SeedUser(DbSet<User> users)
		{
			if (users.Any()) return;

			users.Add(new User()
			{
				Name = "Shad",
				Password = "123"
			});
		}

		private static void Migrate(QuestDbContext db)
		{
			Console.WriteLine("Attempting to apply migrations...");
			try
			{
				db.Database.Migrate();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed: {ex.Message}");
			}
		}
	}
}
