using System.Linq;
using AutoMapper;
using SimpleBetting.Data.Entities;
using SimpleBetting.Service.Models;

namespace SimpleBetting.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.HomeTeam, opts => opts.MapFrom(src => src.Teams.First()))
                .ForMember(dest => dest.AwayTeam, opts => opts.MapFrom(src => src.Teams.Last()));
        }
    }
}