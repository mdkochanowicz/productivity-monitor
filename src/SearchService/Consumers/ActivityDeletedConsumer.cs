using Contracts;
using MassTransit;
using MongoDB.Entities;

namespace SearchService
{
    public class ActivityDeletedConsumer : IConsumer<ActivityDeleted>
    {
        public async Task Consume(ConsumeContext<ActivityDeleted> context)
        {
            Console.WriteLine($"Processing activity: {context.Message.Id}");

            var result = await DB.DeleteAsync<Item>(context.Message.Id);

            if (!result.IsAcknowledged)
            {
                throw new Exception("Could not delete item (mongodb problem)");
            }
        }
    }
}