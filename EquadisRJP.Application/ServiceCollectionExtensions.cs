using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EquadisRJP.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assemblyReference = typeof(ApplicationAssemblyReference).Assembly;
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(ApplicationAssemblyReference)));
            services.AddValidatorsFromAssembly(assemblyReference);
        }
    }
}
