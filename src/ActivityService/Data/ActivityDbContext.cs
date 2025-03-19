using ActivityService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivityService.Data;

public class ActivityDbContext : DbContext
{
    public ActivityDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Activity> Activities { get; set; }
}