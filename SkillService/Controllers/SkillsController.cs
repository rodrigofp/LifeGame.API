using AutoMapper;
using Core.MessageBus;
using Microsoft.AspNetCore.Mvc;
using SkillService.Data;
using SkillService.DTOs;
using SkillService.Models;

namespace SkillService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SkillsController : ControllerBase
	{
		private readonly ISkillRepository _skillRepository;
		private readonly IMapper _mapper;
		private readonly IMessageBus _messageBus;
		private readonly int _levelOneDefaultId;

		public SkillsController(IServiceProvider serviceProvider)
		{
			_mapper = serviceProvider.GetRequiredService<IMapper>();
			_skillRepository = serviceProvider.GetRequiredService<ISkillRepository>();
			_messageBus = serviceProvider.GetRequiredService<IMessageBus>();

			var levelCurveRepository  = serviceProvider.GetRequiredService<ILevelCurveRepository>();
			_levelOneDefaultId = levelCurveRepository.GetAll(l => l.Level == 1)?.FirstOrDefault()?.Id ?? 1;
		}

		[HttpGet]
		public ActionResult<IEnumerable<SkillReadDTO>> GetAllSkills()
		{
			var skills = _skillRepository.GetAll(s => true);

			return Ok(_mapper.Map<IEnumerable<SkillReadDTO>>(skills));
		}

		[HttpGet("{id}", Name = "GetSkill")]
		public ActionResult<SkillCardDTO> GetSkill(int id)
		{
			var skill = _skillRepository.GetById(id);

			return Ok(_mapper.Map<SkillCardDTO>(skill));
		}

		[HttpPost]
		public async Task<ActionResult<SkillReadDTO>> Create(SkillCreateDTO dto)
		{
			var skill = _mapper.Map<Skill>(dto);

			skill.LevelId = _levelOneDefaultId;

			_skillRepository.Create(skill);

			if (!_skillRepository.SaveChanges())
				return BadRequest();

			var skillCreatedDto = _mapper.Map<SkillReadDTO>(skill);

			try
			{
				var skillPublishedDTO = _mapper.Map<SkillPublishedDTO>(skillCreatedDto);
				_messageBus.PublishNewMessage(skillPublishedDTO);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return CreatedAtRoute(nameof(GetSkill), new { Id = skillCreatedDto.Id }, skillCreatedDto);
		}
	}
}
