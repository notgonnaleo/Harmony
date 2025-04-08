using Harmony.Api.Contexts;
using Harmony.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Harmony.Api.Resolvers
{
    public class UserResolver
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UserResolver(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<int> GetTotalLikesGivenAsync([Parent] User user)
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Interactions
                .Where(i => i.UserId == user.Id && i.InteractionType == InteractionType.Like)
                .CountAsync();
        }

        public async Task<IEnumerable<Song>> GetUserUploadedSongs([Parent] User user)
        {
            var context = _contextFactory.CreateDbContext();
            return await context.Songs
                .Where(s => s.Artist!.Id == user.Id)
                .ToListAsync();
        }
    }
}
