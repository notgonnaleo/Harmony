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

        public async Task<IEnumerable<Song>> GetUserLikedSongs([Parent] User user)
        {
            var context = _contextFactory.CreateDbContext();
            var likedSongs = await context.Interactions.Where(x => x.UserId == user.Id && x.InteractionType == InteractionType.Like).ToListAsync();
            var songsInfo = await context.Songs.Where(x => likedSongs.Select(l => l.SongId).Contains(x.Id)).ToListAsync();
            return songsInfo ?? new List<Song>();
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
