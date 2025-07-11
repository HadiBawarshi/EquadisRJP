using EquadisRJP.Application;
using EquadisRJP.Infrastructure;
using EquadisRJP.Service.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);


var app = builder.Build();


//Exception handling middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
