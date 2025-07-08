using EquadisRJP.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquadisRJP.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EquadisRJPDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        }
    }
}
