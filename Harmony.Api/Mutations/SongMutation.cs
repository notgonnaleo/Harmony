using Harmony.Api.Contexts;
using Harmony.Api.Entities;

namespace Harmony.Api.Mutations
{
    public class SongMutation
    {
        public async Task<Song> AddSong([Service] AppDbContext context, string title, int duration, int userId)
        {
            var artist = await context.Users.FindAsync(userId);
            var song = new Song
            {
                Title = title,
                Duration = duration,
                Artist = artist,
                CreatedAt = DateTime.UtcNow,
            };
            context.Songs.Add(song);
            await context.SaveChangesAsync();
            return song;
        }
    }
}
