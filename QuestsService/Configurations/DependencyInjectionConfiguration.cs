using QuestsService.Data;
using QuestsService.Repositories;

namespace QuestsService.Configurations
{
	public static class DependencyInjectionConfiguration
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<IQuestRepository, QuestRepository>();
			services.AddScoped<IQuestHistoryRepository, QuestHistoryRepository>();
			services.AddScoped<ISkillRepository, SkillRepository>();
		}
	}
}
