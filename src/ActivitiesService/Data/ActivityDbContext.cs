using ActivitiesService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ActivitiesService.Data;

    public class ActivityDBContext : DbContext
    {
        public ActivityDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }

       
    }
