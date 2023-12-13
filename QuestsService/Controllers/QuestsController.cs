using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestsService.Data;
using QuestsService.DTOs;
using QuestsService.Models;

namespace QuestsService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class QuestsController : ControllerBase
	{
		private readonly IQuestRepository _questRepository;
		private readonly IQuestHistoryRepository _questHistoryRepository;
		private readonly ISkillRepository _skillRepository;
		private readonly IMapper _mapper;

		public QuestsController(IServiceProvider serviceProvider)
		{
			_questRepository = serviceProvider.GetRequiredService<IQuestRepository>();
			_questHistoryRepository = serviceProvider.GetRequiredService<IQuestHistoryRepository>();
			_skillRepository = serviceProvider.GetRequiredService<ISkillRepository>();
			_mapper = serviceProvider.GetRequiredService<IMapper>();
		}

		[HttpGet]
		public ActionResult<IEnumerable<QuestReadDTO>> GetQuests()
		{
			var quests = _questRepository.GetAll(q => !q.QuestHistories.Any(qh => qh.DateCompleted >= DateTime.Today.AddDays((int)q.Frequency)));

			return Ok(_mapper.Map<IEnumerable<QuestReadDTO>>(quests));
		}

		[HttpGet("{id}", Name = "GetQuest")]
		public ActionResult<QuestReadDTO> GetQuest(int skillid, int id)
		{
			if (!_skillRepository.Exists(skillid))
				return NotFound();

			var quest = _questRepository.GetById(id);

			return Ok(_mapper.Map<QuestReadDTO>(quest));
		}

		[HttpPost]
		public ActionResult<QuestReadDTO> CreateQuest(int skillid, QuestCreateDTO dto)
		{
			if (!_skillRepository.Exists(skillid))
				return NotFound();

			var quest = _mapper.Map<Quest>(dto);

			quest.SkillId = skillid;

			_questRepository.Create(quest);

			if (!_questRepository.SaveChanges())
				return BadRequest();

			var questCreatedDTO = _mapper.Map<QuestReadDTO>(quest);

			return CreatedAtRoute(nameof(GetQuest), new { skillid, id = questCreatedDTO.Id }, questCreatedDTO);
		}

		[HttpPost("{questId}")]
		public ActionResult CompleteQuest(QuestHistoryCreateDTO questHistoryDTO)
		{
			if (!_questRepository.Exists(questHistoryDTO.QuestId))
				return NotFound();

			var questHistory = _mapper.Map<QuestHistory>(questHistoryDTO);

			_questHistoryRepository.Create(questHistory);
			_questHistoryRepository.SaveChanges();

			return Ok();
		}
	}
}
