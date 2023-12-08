using SkillService.DTOs;
using System.Text;
using System.Text.Json;

namespace SkillService.SyncServices
{
	public class QuestClient : IQuestClient
	{
		private readonly HttpClient _httpClient;
		private readonly IConfiguration _configuration;

		public QuestClient(HttpClient httpClient, IConfiguration configuration)
		{
			_httpClient = httpClient;
			_configuration = configuration;
		}

		public async Task SendSkillToQuest(SkillReadDTO skill)
		{
			var httpContent = new StringContent(
				JsonSerializer.Serialize(skill),
				Encoding.UTF8,
				"application/json"
			);

			var response = await _httpClient.PostAsync($"{_configuration["QuestsService"]}", httpContent);

			if (response.IsSuccessStatusCode)
				Console.WriteLine("-- Sync POST to QuestService was OK!");
			else
				Console.WriteLine("-- Sync POST to QuestService was NOT OK!");
		}
	}
}
