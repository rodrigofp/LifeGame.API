using SkillService.Data;
using SkillService.Repositories;

namespace SkillService.Configurations
{
	public static class DependecyInjectionConfiguration
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<ILevelCurveRepository, LevelCurveRepository>();
			//services.AddScoped<IRewardRepository, RewardRepository>();
			services.AddScoped<ISkillRepository, SkillRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
		}
	}
}
