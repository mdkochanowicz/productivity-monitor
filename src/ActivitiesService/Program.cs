using ActivitiesService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ActivityDBContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.



app.UseAuthorization();

app.MapControllers();

try{
    DbInitializer.InitDb(app);
}
catch(Exception e){
    System.Console.WriteLine(e);
    //System.Console.WriteLine(e.StackTrace);
}

app.Run();
