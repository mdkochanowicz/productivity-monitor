using ActivitiesService.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<ActivityDBContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();


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
