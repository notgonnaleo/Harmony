﻿using Harmony.Api.Contexts;
using Harmony.Api.Mutations;
using Harmony.Api.Types;

namespace Harmony.Api.Extensions
{
    public static class GraphQLServiceExtensions
    {
        public static IServiceCollection AddGraphQLSetup(this IServiceCollection services)
        {
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<InteractionMutation>()
                .AddType<UserType>()
                .RegisterDbContextFactory<AppDbContext>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            return services;
        }
    }
}
