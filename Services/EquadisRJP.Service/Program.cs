using EquadisRJP.Application;
using EquadisRJP.Infrastructure;
using EquadisRJP.Service.Middlewares;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;


var logger = LogManager.Setup()
    .LoadConfigurationFromAppSettings()
    .GetCurrentClassLogger();

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Remove default logging
    builder.Logging.ClearProviders();
    //In dev use trace
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    //In prod
    //builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);

    builder.Host.UseNLog(); // Register NLog



    // Add services to the container.

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();


    builder.Services.AddApplicationServices();

    builder.Services.AddInfrastructureServices(builder.Configuration);

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "EquadisRJP.API", Version = "v1" });
    });


    var app = builder.Build();


    //Exception handling middleware
    app.UseMiddleware<ExceptionHandlingMiddleware>();

    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EquadisRJP.API v1"));
    }

    app.UseRouting();

    // Configure the HTTP request pipeline.

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Stopped due to an exception during startup.");
    throw;
}
finally
{
    LogManager.Shutdown(); // Flush and stop NLog

}


