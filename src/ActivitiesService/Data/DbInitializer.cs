
using ActivitiesService.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ActivitiesService.Data;

public class DbInitializer 
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<ActivityDBContext>());
    }

    private static void SeedData(ActivityDBContext? context)
    {
        context.Database.Migrate();

        if (context.Activities.Any())
        {
            System.Console.WriteLine("Already have data in the database. Skipping seeding.");
            return;
        }

        var activities = new List<Activity>()
        {
            new Activity
            {
                Id = Guid.Parse("f5b1b3b3-0b6b-4b1b-8b3b-0b6b4b1b8b3b"),
                Status = Status.InProgress,
                //ReserveTime = 50,
                Author = "Michal",
                User = "Michal",
                //ActivityEnd = DateTime.UtcNow.AddHours(1),
                Task = new Task
                {
                    Id = Guid.Parse("f5b1b3b3-0b6b-4b1b-8b3b-0b6b4b1b8b3b"),
                    Name = "Task 1",
                    Description = "Task 1 Description",
                }
            },
            new Activity
            {
                Id = Guid.Parse("f5b1b3b3-0b6b-4b1b-8b3b-0b6b4b1b8b3c"),
                Status = Status.InProgress,
                //ReserveTime = 50,
                Author = "Dariusz",
                User = "Dariusz",
                //ActivityEnd = DateTime.UtcNow.AddHours(1),
                Task = new Task
                {
                    Id = Guid.Parse("f5b1b3b3-0b6b-4b1b-8b3b-0b6b4b1b8b3c"),
                    Name = "Task 2",
                    Description = "Task 2 Description",
                }
            },
        };

        context.AddRange(activities);

        context.SaveChanges();
    }
}