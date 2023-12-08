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
			CreateMap<SkillPublishedDTO, Skill>()
				.ForMember(dest => dest.ExternalId, map => map.MapFrom(src => src.Id))
				.ForMember(dest => dest.Id, map => map.MapFrom(src => 0));
		}
	}
}
