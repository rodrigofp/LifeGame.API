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
			CreateMap<Skill, SkillCardDTO>()
				.ForMember(dest => dest.CurrentLevel, map => map.MapFrom(src => src.Level.Level))
				.ForMember(dest => dest.ExpToNextLevel, map => map.MapFrom(src => src.Level.ExpToNextLevel));
		}
	}
}
