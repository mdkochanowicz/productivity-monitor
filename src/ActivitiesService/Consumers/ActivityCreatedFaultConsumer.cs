namespace ActivitiesService;

    public class ActivityCreatedFaultConsumer : IConsumer<Fault<ActivityCreated>>
    {
        public async Task Consume(ConsumeContext<Fault<ActivityCreated>> context)
        {
            Console.WriteLine($"Activity creation failed: {context.Message.Message}");

            var exception = context.Message.Exceptions.First();

            if(exception.ExceptionType == "System.ArgumentException")
            {
                context.Message.Name = "BadBar";
                await context.Publish(context.Message.Message);
            }
            else
            {
                Console.WriteLine("Unhandled exception");
            }
        }
    }