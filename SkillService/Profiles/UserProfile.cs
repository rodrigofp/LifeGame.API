using AutoMapper;
using SkillService.DTOs;
using SkillService.Models;

namespace SkillService.Profiles
{
	public class UserProfile : Profile
	{
		public UserProfile()
		{
			CreateMap<User, UserReadDTO>();
		}
	}
}
