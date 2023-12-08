using AutoMapper;
using QuestsService.DTOs;
using QuestsService.Models;

namespace QuestsService.Profiles
{
	public class QuestHistoryProfile : Profile
	{
		public QuestHistoryProfile()
		{
			CreateMap<QuestHistory, QuestHistoryReadDTO>()
				.ForMember(q => q.Quest, map => map.MapFrom(src => src.Quest.Name))
				.ForMember(q => q.Skill, map => map.MapFrom(src => src.Quest.Skill.Name))
				.ForMember(q => q.ExpReward, map => map.MapFrom(src => src.Quest.ExpReward));
			CreateMap<QuestHistoryCreateDTO, QuestHistory>();
		}
	}
}