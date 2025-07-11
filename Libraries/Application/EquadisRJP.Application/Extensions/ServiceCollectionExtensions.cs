using EquadisRJP.Application.Behaviour;
using EquadisRJP.Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace EquadisRJP.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assemblyReference = typeof(ApplicationAssemblyReference).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assemblyReference));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(config =>
            {
                config.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;

            }, Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


            services.AddScoped<IAuditService, AuditService>();
        }
    }
}
