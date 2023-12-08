using AutoMapper;
using Microsoft.OpenApi.Extensions;
using QuestsService.DTOs;
using QuestsService.Models;

namespace QuestsService.Profiles
{
	public class QuestProfile : Profile
	{
		public QuestProfile()
		{
			CreateMap<Quest, QuestReadDTO>()
				.ForMember(q => q.Frequency, map => map.MapFrom(src => src.Frequency.GetDisplayName()));
			CreateMap<QuestCreateDTO, Quest>()
				.ForMember(q => q.Frequency, map => map.MapFrom(src => (Frequency)src.Frequency));
		}
	}
}
