using Microsoft.EntityFrameworkCore;
using SkillService.Models;

namespace SkillService.Data
{
	public static class SeedDb
	{
		private const int MIN_LEVEL = 1;
		private const int MAX_LEVEL = 50;
		private const int INITIAL_EXP = 10;

		public static void Seed(this WebApplication app, bool isProduction)
		{
			using var serviceScope = app.Services.CreateScope();
			var db = serviceScope.ServiceProvider.GetRequiredService<SkillDbContext>();
			
			if (isProduction)
				Migrate(db);

			SeedData(db);
		}

		private static void Migrate(SkillDbContext db)
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

		private static void SeedData(SkillDbContext db)
		{
			SeedUser(db.Users);
			SeedLevelCurve(db.LevelCurves);
			db.SaveChanges();
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

		private static void SeedLevelCurve(DbSet<LevelCurve> levelCurve)
		{
			if (levelCurve.Any()) return;

			var previousCurveExp = 0;
			var currentCurveExp = 1;
			var levelExp = INITIAL_EXP;
			levelCurve.Add(new LevelCurve { Level = MIN_LEVEL, ExpToNextLevel = INITIAL_EXP });
			for (int level = MIN_LEVEL + 1; level <= MAX_LEVEL; level++)
			{
				var nextLevel = currentCurveExp + previousCurveExp;
				levelExp += nextLevel;
				previousCurveExp = currentCurveExp;
				currentCurveExp = nextLevel;
				levelCurve.Add(new LevelCurve { Level = level, ExpToNextLevel = levelExp });
			}
		}
	}
}
