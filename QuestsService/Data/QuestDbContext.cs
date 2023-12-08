using Microsoft.EntityFrameworkCore;
using QuestsService.Models;

namespace QuestsService.Data
{
	public class QuestDbContext : DbContext
	{
		public QuestDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(
				e => e.GetForeignKeys()))
				relationship.DeleteBehavior = DeleteBehavior.ClientNoAction;

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuestDbContext).Assembly);
		}

		public DbSet<Quest> Quests { get; set; }
		public DbSet<QuestHistory> QuestHistories { get; set; }
		public DbSet<Skill> Skills { get; set; }
		public DbSet<User> Users { get; set; }

	}
}
