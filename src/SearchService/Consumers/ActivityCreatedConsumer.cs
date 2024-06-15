using System.Diagnostics;
using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class ActivityCreatedConsumer : IConsumer<ActivityCreated>
{
    private readonly IMapper _mapper;
    public ActivityCreatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task Consume(ConsumeContext<ActivityCreated> context)
    {
        Console.WriteLine($"Processing activity: {context.Message.Id}");

        var item = _mapper.Map<Item>(context.Message);

        await item.SaveAsync();
    }

}
