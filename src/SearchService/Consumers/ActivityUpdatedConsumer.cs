using AutoMapper;
using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService;

public class ActivityUpdatedConsumer : IConsumer<ActivityUpdated>
{
    private readonly IMapper _mapper;
    public ActivityUpdatedConsumer(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task Consume(ConsumeContext<ActivityUpdated> context)
    {
        Console.WriteLine($"Processing activity: {context.Message.Id}");

        var item = _mapper.Map<Item>(context.Message);/////

        var result = await DB.Update<Item>()
            .Match(i => i.ID == item.ID)
            .ModifyOnly(x => new
            {
                x.Name,
                x.Description,
                x.Experience,
                x.PredictedTime,
                x.Category
                
            }, item)
            
            .ExecuteAsync();

            if(!result.IsAcknowledged)
            {
                throw new Exception("Could not update item (mongodb problem)");
            }
    }

}