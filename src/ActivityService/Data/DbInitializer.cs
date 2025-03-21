using ActivityService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.Data;

public class DbInitializer
{
    public static void InitDb(WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        SeedData(scope.ServiceProvider.GetService<ActivityDbContext>());
    }

    private static void SeedData(ActivityDbContext context)
    {
        context.Database.Migrate();

        if(context.Activities.Any())
        {
            Console.WriteLine("Database already seeded");
            return;
        }

        var activities = new List<Activity>()
        {
            new() {
                Id = Guid.Parse("f4b3f3b3-7f1d-4b1d-8d1e-1b1f4b1f4b1r"),
                Status = Status.Live,
                ReserveTime = 2000,
                Author = "John Doe",
                ActivityEnd = DateTime.UtcNow.AddHours(2),
                Task = new Entities.Task
                {
                    Name = "Task 1",
                    Description = "Task 1 Description",
                    PredictedTime = 1000,
                    Category = "Category 1",
                    Experience = 1,
                    ImageUrl = "https://via.placeholder.com/150"

                }
            },
            new() {
                Id = Guid.Parse("f4b3f3b3-7f1d-4b1d-8d1e-1b1f4b1f4b1e"),
                Status = Status.Live,
                ReserveTime = 2500,
                Author = "John Doe",
                ActivityEnd = DateTime.UtcNow.AddHours(2),
                Task = new Entities.Task
                {
                    Name = "Task 2",
                    Description = "Task 2 Description",
                    PredictedTime = 1000,
                    Category = "Category 2",
                    Experience = 2,
                    ImageUrl = "https://via.placeholder.com/150"

                }
            },
            new() {
                Id = Guid.Parse("f4b3f3b3-7f1d-4b1d-8d1e-1b1f4b1f4b1w"),
                Status = Status.Live,
                ReserveTime = 1000,
                Author = "John Doe",
                ActivityEnd = DateTime.UtcNow.AddHours(2),
                Task = new Entities.Task
                {
                    Name = "Task 3",
                    Description = "Task 3 Description",
                    PredictedTime = 1000,
                    Category = "Category 3",
                    Experience = 3,
                    ImageUrl = "https://via.placeholder.com/150"

                }
            },
            new() {
                Id = Guid.Parse("f4b3f3b3-7f1d-4b1d-8d1e-1b1f4b1f4b1q"),
                Status = Status.Live,
                ReserveTime = 3000,
                Author = "John Doe",
                ActivityEnd = DateTime.UtcNow.AddHours(2),
                Task = new Entities.Task
                {
                    Name = "Task 4",
                    Description = "Task 4 Description",
                    PredictedTime = 1000,
                    Category = "Category 4",
                    Experience = 4,
                    ImageUrl = "https://via.placeholder.com/150"

                }
            }
        };

        context.AddRange(activities);
        context.SaveChanges();
    }
}