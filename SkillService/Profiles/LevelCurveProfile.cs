using AutoMapper;
using SkillService.DTOs;
using SkillService.Models;

namespace SkillService.Profiles
{
	public class LevelCurveProfile : Profile
	{
		public LevelCurveProfile()
		{
			CreateMap<LevelCurve, LevelCurveReadDTO>();
		}
	}
}