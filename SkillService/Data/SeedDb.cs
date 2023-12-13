using Microsoft.EntityFrameworkCore;
using SkillService.Models;

namespace SkillService.Data
{
	public static class SeedDb
	{
		private const int INITIAL_LEVEL = 1;
		private const int CAP_LEVEL = 100;
		private const int BASE_EXP = 10;
		private const decimal MULTIPLIER = 0.7M;
		private const int CONTROL_NUMBER = 5;

		public static void Seed(this WebApplication app)
		{
			using var serviceScope = app.Services.CreateScope();
			var db = serviceScope.ServiceProvider.GetRequiredService<SkillDbContext>();

			Migrate(db);
			SeedData(db);
		}

		private static void Migrate(SkillDbContext db)
		{
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
			SeedLevelCurve(db.LevelCurves);
			db.SaveChanges();
		}

		private static void SeedLevelCurve(DbSet<LevelCurve> levelCurve)
		{
			if (levelCurve.Any()) return;

			var exp = BASE_EXP;

			for (int level = INITIAL_LEVEL; level <= CAP_LEVEL; level++)
			{
				var levelExp = (int) Math.Floor(exp + level * MULTIPLIER);
				levelCurve.Add(new LevelCurve { Level = level, ExpToNextLevel = levelExp });
				if (level > CONTROL_NUMBER)
					exp += level - CONTROL_NUMBER;
				else
					exp += level;
			}
		}
	}
}
