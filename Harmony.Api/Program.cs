using Harmony.Api;
using Harmony.Api.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<AppDbContext>();
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .RegisterDbContextFactory<AppDbContext>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseAuthorization();

app.MapGraphQL("/nitro");

app.Run();
