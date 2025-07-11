using EquadisRJP.Application.ExternalServices;
using EquadisRJP.Domain.Repositories;
using EquadisRJP.Infrastructure.Data;
using EquadisRJP.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EquadisRJP.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EquadisRJPDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


            services.AddHttpClient<IIdentityAuthClient, IdentityAuthClient>(c =>
            {
                c.BaseAddress = new Uri(configuration["IdentityAuth:BaseUrl"]);
                c.DefaultRequestHeaders.Accept.Add(new("application/json"));
            });



            services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<EquadisRJPDbContext>());
            services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IRetailerRepository, RetailerRepository>();
            services.AddScoped<IPartnershipRepository, PartnershipRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();


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

                //options.Authority = configuration["JwtSettings:Issuer"];
                //options.Audience = configuration["JwtSettings:Audience"];

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Secret"] ?? string.Empty))
                };
            });
        }
    }
}
