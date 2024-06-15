using AutoMapper;
using ActivitiesService.Entities;
using ActivitiesService.DTOs;
using Contracts;

namespace ActivitiesService;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Activity, ActivityDto>().IncludeMembers(x => x.Task);
        CreateMap<Task, ActivityDto>();
        CreateMap<CreateActivityDto, Activity>()
            .ForMember(d => d.Task, o => o.MapFrom(s => s));
        CreateMap<CreateActivityDto, Task>();
        CreateMap<ActivityDto, ActivityCreated>();
    }
}