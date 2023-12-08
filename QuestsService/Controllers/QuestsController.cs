using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestsService.Data;
using QuestsService.DTOs;
using QuestsService.Models;

namespace QuestsService.Controllers
{
	[Route("api/q/skills/{skillid}/[controller]")]
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
		public ActionResult<IEnumerable<QuestReadDTO>> GetQuests(int skillid)
		{
			if (!_skillRepository.Exists(skillid))
				return NotFound();

			var quests = _questRepository.GetAll(q => q.SkillId == skillid);

			return Ok(_mapper.Map<IEnumerable<QuestReadDTO>>(quests));
		}

		[HttpGet("{id}", Name = "GetQuest")]
		public ActionResult<QuestReadDTO> GetById(int skillid, int id)
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

			return CreatedAtRoute(nameof(GetById), new { skillid, id = questCreatedDTO.Id }, questCreatedDTO);
		}
	}
}
