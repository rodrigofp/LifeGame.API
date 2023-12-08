using AutoMapper;
using QuestsService.DTOs;
using QuestsService.Models;

namespace QuestsService.Profiles
{
	public class SkillProfile : Profile
	{
		public SkillProfile()
		{
			CreateMap<Skill, SkillReadDTO>();
		}
	}
}
