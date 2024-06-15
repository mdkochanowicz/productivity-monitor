using ActivitiesService.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesService.Data;

    public class ActivityDBContext : DbContext
    {
        public ActivityDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.AddInboxStateEntity();
        modelBuilder.AddOutboxMessageEntity();
        modelBuilder.AddOutboxStateEntity();
    }



}
