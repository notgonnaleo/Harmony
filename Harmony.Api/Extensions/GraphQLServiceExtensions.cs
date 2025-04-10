using Harmony.Api.Contexts;
using Harmony.Api.Schemas;

namespace Harmony.Api.Extensions
{
    public static class GraphQLServiceExtensions
    {
        public static IServiceCollection AddGraphQLSetup(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<UserSchema>()
                .AddType<SongSchema>()
                .RegisterDbContextFactory<AppDbContext>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            return services;
        }
    }
}
