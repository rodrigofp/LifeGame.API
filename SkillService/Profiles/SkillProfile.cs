using AutoMapper;
using SkillService.DTOs;
using SkillService.Models;

namespace SkillService.Profiles
{
	public class SkillProfile : Profile
	{
		public SkillProfile()
		{
			CreateMap<Skill, SkillReadDTO>();
			CreateMap<SkillCreateDTO, Skill>();
			CreateMap<SkillReadDTO, SkillPublishedDTO>();
		}
	}
}
