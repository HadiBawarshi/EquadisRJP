using EquadisRJP.Application;
using EquadisRJP.Infrastructure;
using EquadisRJP.Service.Middlewares;
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


