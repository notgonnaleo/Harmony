using Harmony.Api.Contexts;
using Harmony.Api.Mutations;
using Harmony.Api.Resolvers;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            // Resolver
            services.AddScoped<UserResolver>();

            return services;
        }
    }
}
