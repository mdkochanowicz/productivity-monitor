/*
using Contracts;
using MassTransit;

namespace ActivitiesService;

    public class ActivityCreatedFaultConsumer : IConsumer<Fault<ActivityCreated>>
    {
        public async Task Consume(ConsumeContext<Fault<ActivityCreated>> context)
        {
            Console.WriteLine($"Activity creation failed");

            var exception = context.Message.Exceptions.First();

            if(exception.ExceptionType == "System.ArgumentException")
            {
                context.Message.Message.Name = "BadBar";
                await context.Publish(context.Message.Message);
            }
            else
            {
                Console.WriteLine("Unhandled exception");
            }
        }
    }
    /*
    System.Threading.Tasks.Task IConsumer<Fault<ActivityCreated>>.Consume(ConsumeContext<Fault<ActivityCreated>> context)
    {
        throw new NotImplementedException();
    }
    */
