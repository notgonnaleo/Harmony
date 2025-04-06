using Harmony.Api;
using Harmony.Api.Contexts;
using Harmony.Api.Mutations;
using Harmony.Api.Resolvers;
using Harmony.Api.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AppDbContext>();
builder.Services
    .AddScoped<UserResolver>()
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<InteractionMutation>()
    .AddType<UserType>()
    .RegisterDbContextFactory<AppDbContext>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseAuthorization();

app.MapGraphQL("/graphql");

app.Run();
