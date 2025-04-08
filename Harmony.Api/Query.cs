using Harmony.Api.Contexts;
using Harmony.Api.Entities;

namespace Harmony.Api
{
    public class Query
    {
        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Song> GetSongs([Service] AppDbContext context)
        {
            return context.Songs;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Interaction> GetInteractions([Service] AppDbContext context)
        {
            return context.Interactions;
        }

        [UsePaging]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] AppDbContext context)
        {
            return context.Users;
        }
    }
}
