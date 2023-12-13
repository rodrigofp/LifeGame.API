using Microsoft.EntityFrameworkCore;
using SkillService.Models;

namespace SkillService.Data
{
	public class SkillDbContext : DbContext
	{
		public SkillDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(
				e => e.GetForeignKeys()))
			{
				relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;
			}
		}

		public DbSet<LevelCurve> LevelCurves { get; set; }
		public DbSet<Skill> Skills { get; set; }
	}
}
