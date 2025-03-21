using AutoMapper;
using ActivityService.Entities;
using ActivityService.DTOs;

namespace ActivityService.RequestHelpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, ActivityDto>().IncludeMembers(x => x.Task);
        CreateMap<Entities.Task, ActivityDto>();
        CreateMap<CreateActivityDto, Activity>()
            .ForMember(d => d.Task, o => o.MapFrom(s => s));
        CreateMap<CreateActivityDto, Entities.Task>();
    }
}