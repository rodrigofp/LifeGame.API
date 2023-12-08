using AutoMapper;
using QuestsService.Data;
using QuestsService.DTOs;
using QuestsService.Models;
using System.Text.Json;

namespace QuestsService.EventProcessing
{
	public class EventProcessor : IEventProcessor
	{
		private readonly IServiceScopeFactory _serviceFactory;
		private readonly IMapper _mapper;

		public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
		{
			_serviceFactory = scopeFactory;
			_mapper = mapper;
		}

		public void ProcessEvent(string message)
		{
			var eventType = DetermineEvent(message);

			switch (eventType)
			{
				case EventType.SkillPublished:
					AddSkill(message);
					return;
				default:
					Console.WriteLine("Event not mapped");
					return;
			}
		}

		private void AddSkill(string skillPublishedMessage)
		{
			using var scope = _serviceFactory.CreateScope();
			var repository = scope.ServiceProvider.GetRequiredService<ISkillRepository>();

			var skillPublishedDTO = JsonSerializer.Deserialize<SkillPublishedDTO>(skillPublishedMessage);

			try
			{
				var skill = _mapper.Map<Skill>(skillPublishedDTO);

				if (repository.ExternalSkillIdExists(skill.ExternalId))
					throw new Exception("Skill already exists");

				repository.Create(skill);
				repository.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}

		private EventType DetermineEvent(string notificationMessage)
		{
			var eventType = JsonSerializer.Deserialize<GenericEventDTO>(notificationMessage);

			switch (eventType.Event)
			{
				case "Skill_Published":
					return EventType.SkillPublished;
				default:
					return EventType.Undertermined;
			}
		}
		
	}

	enum EventType
	{
		SkillPublished,
		Undertermined
	}
}