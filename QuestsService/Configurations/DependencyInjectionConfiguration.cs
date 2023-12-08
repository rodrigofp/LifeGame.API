using QuestsService.Data;
using QuestsService.EventProcessing;
using QuestsService.Repositories;

namespace QuestsService.Configurations
{
	public static class DependencyInjectionConfiguration
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddSingleton<IEventProcessor, EventProcessor>();

			services.AddScoped<IQuestRepository, QuestRepository>();
			services.AddScoped<IQuestHistoryRepository, QuestHistoryRepository>();
			services.AddScoped<ISkillRepository, SkillRepository>();
		}
	}
}
