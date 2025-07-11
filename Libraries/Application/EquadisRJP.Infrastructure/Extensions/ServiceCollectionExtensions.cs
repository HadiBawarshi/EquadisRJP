using EquadisRJP.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EquadisRJP.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EquadisRJPDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        }


        public static void AddJWTAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            // Set up JWT Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            })
            .AddJwtBearer(options =>
            {

                options.Authority = configuration["JwtSettings:Issuer"];
                options.Audience = configuration["JwtSettings:Audience"];
                //options.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuer = true,
                //    ValidateAudience = true,
                //    ValidateLifetime = true,
                //    ValidateIssuerSigningKey = true,
                //    ValidIssuer = configuration["JwtSettings:Issuer"],
                //    ValidAudience = configuration["JwtSettings:Audience"],
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"] ?? string.Empty))
                //};
            });
        }
    }
}
